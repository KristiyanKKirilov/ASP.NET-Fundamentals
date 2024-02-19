using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Models;
using System.Globalization;
using System.Security.Claims;

namespace SoftUniBazar.Controllers
{
	[Authorize]
	public class AdController : Controller
	{
		private readonly BazarDbContext data;

        public AdController(BazarDbContext context)
        {
			data = context;
        }
        public async Task<IActionResult> All()
		{
			var model = await data.Ads
				.Select(a => new AdViewModel()
				{
					Id = a.Id,
					Name = a.Name,
					Description = a.Description,
					ImageUrl = a.ImageUrl,
					CreatedOn = a.CreatedOn.ToString(DataConstants.DateFormat),
					Price = decimal.Parse(a.Price.ToString("F2")),
					Category = a.Category.Name,
					Owner = a.Owner.UserName
				})
				.ToListAsync();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddToCart(int id)
		{
			var currentAd = await data.Ads
				.Where(a => a.Id == id)
				.Include(a => a.AdsBuyers)
				.FirstOrDefaultAsync();

			if(currentAd == null)
			{
				return BadRequest();
			}

			string userId = GetUserId();

			if(!currentAd.AdsBuyers.Any(ab => ab.BuyerId == userId))
			{
				currentAd.AdsBuyers
					.Add(new AdBuyer()
					{
						AdId = currentAd.Id,
						BuyerId = userId,
					});

				await data.SaveChangesAsync();
			}

			return RedirectToAction(nameof(Cart));

		}

		public async Task<IActionResult> RemoveFromCart(int id)
		{
			var currentAd = await data.Ads
				.Where(a => a.Id == id)
				.Include(a => a.AdsBuyers)
				.FirstOrDefaultAsync();

			if (currentAd == null)
			{
				return BadRequest();
			}

			string userId = GetUserId();

			var adBuyer = data.AdsBuyers
				.FirstOrDefault(ab => ab.BuyerId == userId);

			if(adBuyer == null)
			{
				return BadRequest();
			}

			currentAd.AdsBuyers
				.Remove(adBuyer);

			await data.SaveChangesAsync();

			return RedirectToAction(nameof(All));
		}

		[HttpGet]
		public async Task<IActionResult> Cart()
		{
			string userId = GetUserId();

			var model = await data.AdsBuyers
				.Where(ab => ab.BuyerId == userId)
				.AsNoTracking()
				.Select(ab => new AdViewModel()
				{
					Id = ab.Ad.Id,
					Name = ab.Ad.Name,
					Description = ab.Ad.Description,
					Category = ab.Ad.Category.Name,
					CreatedOn = ab.Ad.CreatedOn.ToString(DataConstants.DateFormat),
					ImageUrl = ab.Ad.ImageUrl,
					Owner = ab.Ad.Owner.UserName,
					Price = decimal.Parse(ab.Ad.Price.ToString("F2"))
				})
				.ToListAsync();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = new AdFormViewModel();
			model.Categories = await GetCategories();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(AdFormViewModel model)
		{			

			if(!ModelState.IsValid)
			{
				return View(model);
			}

			var entity = new Ad()
			{
				Name = model.Name,
				Description = model.Description,
				CategoryId = model.CategoryId,
				CreatedOn = DateTime.Now,
				Price = model.Price,
				ImageUrl = model.ImageUrl,
				OwnerId = GetUserId()				
			};

			await data.Ads.AddAsync(entity);
			await data.SaveChangesAsync();

			return RedirectToAction(nameof(All));
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var currentAd = await data.Ads.FindAsync(id);

			if(currentAd == null) 
			{
				return BadRequest();
			}

			var userId = GetUserId();

			if(userId != currentAd.OwnerId)
			{
				return Unauthorized();
			}

			var model = new AdFormViewModel()
			{
				Name = currentAd.Name,
				Description = currentAd.Description,
				CategoryId = currentAd.CategoryId,
				ImageUrl = currentAd.ImageUrl,
				Price = currentAd.Price
			};

			model.Categories = await GetCategories();

			return View(model);
		}

		[HttpPost] 
		public async Task<IActionResult> Edit(AdFormViewModel model, int id)
		{
			var currentAd = await data.Ads.FindAsync(id);

			if (currentAd == null)
			{
				return BadRequest();
			}

			var userId = GetUserId();

			if (userId != currentAd.OwnerId)
			{
				return Unauthorized();
			}

			if (!ModelState.IsValid)
			{
				model.Categories = await GetCategories();
				return View(model);
			}

			currentAd.Name = model.Name;	
			currentAd.Description = model.Description;
			currentAd.CategoryId = model.CategoryId;
			currentAd.Price = model.Price;
			currentAd.ImageUrl = model.ImageUrl;

			await data.SaveChangesAsync();
			return RedirectToAction(nameof(All));
		}


		private string GetUserId()
		{
			return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
		}

		private async Task<IEnumerable<Category>> GetCategories()
		{
			return await data.Categories
				.ToListAsync();
		}
	}
}
