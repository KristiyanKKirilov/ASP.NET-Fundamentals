using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models;
using System.Globalization;
using System.Security.Claims;

namespace SeminarHub.Controllers
{
	[Authorize]
	public class SeminarController : Controller
	{
		private readonly SeminarHubDbContext data;

		public SeminarController(SeminarHubDbContext context)
		{
			data = context;
		}

		public async Task<IActionResult> All()
		{
			var model = await data.Seminars
				.AsNoTracking()
				.Select(s => new SeminarViewModel()
				{
					Id = s.Id,
					Topic = s.Topic,
					Lecturer = s.Lecturer,
					Organizer = s.Organizer.UserName,
					Category = s.Category.Name,
					DateAndTime = s.DateAndTime.ToString(DataConstants.DateFormat)
				})
				.ToListAsync();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = new SeminarFormViewModel();
			model.Categories = await GetCategories();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(SeminarFormViewModel model)
		{
			DateTime date = DateTime.Now;

			if (!DateTime.TryParseExact(model.DateAndTime,
				DataConstants.DateFormat,
				CultureInfo.InvariantCulture,
				DateTimeStyles.None,
				out date))
			{
				ModelState.AddModelError(nameof(model.DateAndTime), ErrorMessages.InvalidDateFormatError);
			}

			if (!ModelState.IsValid)
			{
				model.Categories = await GetCategories();
				return View(model);
			}

			var entity = new Seminar()
			{
				Topic = model.Topic,
				Lecturer = model.Lecturer,
				Details = model.Details,
				CategoryId = model.CategoryId,
				DateAndTime = date,
				OrganizerId = GetUserId(),
				Duration = model.Duration				
			};

			await data.Seminars.AddAsync(entity);
			await data.SaveChangesAsync();

			return RedirectToAction(nameof(All));			
		}

		[HttpPost]
		public async Task<IActionResult> Join(int id)
		{
			var currentSeminar = await data
				.Seminars
				.Where(s => s.Id == id)
				.Include(s => s.SeminarsParticipants)
				.FirstOrDefaultAsync();

			if(currentSeminar == null)
			{
				return BadRequest();
			}

			var userId = GetUserId();

			if(!currentSeminar.SeminarsParticipants.Any(sp => sp.ParticipantId == userId))
			{
				currentSeminar.SeminarsParticipants.Add(new SeminarParticipant()
				{
					SeminarId = id,
					ParticipantId = userId
				});

				await data.SaveChangesAsync();
			}

			return RedirectToAction(nameof(Joined));
		}

		[HttpGet]
		public async Task<IActionResult> Joined()
		{
			var userId = GetUserId();

			var model = await data.SeminarsParticipants
				.Where(sp => sp.ParticipantId == userId)
				.AsNoTracking()
				.Select(sp => new SeminarViewModel()
				{
					Id = sp.Seminar.Id,
					Topic = sp.Seminar.Topic,
					Lecturer = sp.Seminar.Lecturer,
					Category = sp.Seminar.Category.Name,
					Organizer = sp.Seminar.Organizer.UserName,
					DateAndTime = sp.Seminar.DateAndTime.ToString(DataConstants.DateFormat)
				}).ToListAsync();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var seminar = await data.Seminars.FindAsync(id);

			if(seminar == null)
			{
				return BadRequest();
			}

			var userId = GetUserId();

			if(userId != seminar.OrganizerId)
			{
				return Unauthorized();
			}

			var model = new SeminarFormViewModel()
			{
				Topic = seminar.Topic,
				Lecturer = seminar.Lecturer,
				Duration = seminar.Duration,
				DateAndTime = seminar.DateAndTime.ToString(DataConstants.DateFormat),
				CategoryId = seminar.CategoryId,
				Details = seminar.Details
			};

			model.Categories = await GetCategories();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(SeminarFormViewModel model, int id)
		{
			var seminar = await data.Seminars.FindAsync(id);

			if (seminar == null)
			{
				return BadRequest();
			}

			var userId = GetUserId();

			if (userId != seminar.OrganizerId)
			{
				return Unauthorized();
			}

			DateTime date = DateTime.Now;

			if (!DateTime.TryParseExact(model.DateAndTime,
				DataConstants.DateFormat,
				CultureInfo.InvariantCulture,
				DateTimeStyles.None,
				out date))
			{
				ModelState.AddModelError(nameof(model.DateAndTime), ErrorMessages.InvalidDateFormatError);
			}

			if(!ModelState.IsValid)
			{
				model.Categories = await GetCategories();
				return View(model);
			}

			seminar.Topic = model.Topic;
			seminar.Lecturer = model.Lecturer;
			seminar.Details = model.Details;
			seminar.DateAndTime = date;
			seminar.Duration = model.Duration;
			seminar.CategoryId = model.CategoryId;

			await data.SaveChangesAsync();

			return RedirectToAction(nameof(All));
		}

		[HttpPost]
		public async Task<IActionResult> Leave(int id)
		{
			var seminar = await data.Seminars
				.Where(s => s.Id == id)
				.Include(s => s.SeminarsParticipants)
				.FirstOrDefaultAsync();

			if(seminar == null)
			{
				return BadRequest();
			}

			var userId = GetUserId();

			var seminarParticipant = seminar.SeminarsParticipants
				.FirstOrDefault(sp => sp.ParticipantId == userId);

			if(seminarParticipant == null)
			{
				return BadRequest();
			}

			seminar.SeminarsParticipants.Remove(seminarParticipant);
			await data.SaveChangesAsync();

			return RedirectToAction(nameof(Joined));
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var model = await data.Seminars
				.AsNoTracking()
				.Where(s => s.Id == id)	
				.Select(s => new SeminarDetailsViewModel()
				{
					Id = s.Id,
					Topic = s.Topic,
					Lecturer = s.Lecturer,
					DateAndTime = s.DateAndTime.ToString(DataConstants.DateFormat),
					Category = s.Category.Name,
					Details = s.Details,
					Duration = s.Duration,
					Organizer = s.Organizer.UserName
				})
				.FirstOrDefaultAsync();

			if(model == null)
			{
				return BadRequest();
			}

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var seminar = await data.Seminars
				.FindAsync(id);

			if (seminar == null)
			{
				return BadRequest();
			}

			var userId = GetUserId();

			if (seminar.OrganizerId != userId)
			{
				return Unauthorized();
			}

			var model = new SeminarDeleteViewModel()
			{
				Id = seminar.Id,
				DateAndTime = seminar.DateAndTime.ToString(DataConstants.DateFormat),
				Topic = seminar.Topic
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(SeminarDeleteViewModel model)
		{
			var seminar = await data.Seminars
				.FindAsync(model.Id);

			if(seminar == null)
			{
				return BadRequest();
			}

			var userId = GetUserId();

			if(seminar.OrganizerId != userId)
			{
				return Unauthorized();
			}

			var seminarToDelete = await data.SeminarsParticipants
				.FirstOrDefaultAsync(sp => sp.SeminarId == seminar.Id);

			if(seminarToDelete != null)
			{				
					data.SeminarsParticipants.Remove(seminarToDelete);				
			}			

			data.Seminars.Remove(seminar);
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
