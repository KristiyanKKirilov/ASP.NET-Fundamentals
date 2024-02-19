using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly HomiesDbContext data;

        public EventController(HomiesDbContext context)
        {
            data = context;
        }
        public async Task<IActionResult> All()
        {
            var events = await data.Events
                .AsNoTracking()
                .Select(e => new EventViewModel(
                   e.Id,
                   e.Name,
                   e.Start,
                   e.Type.Name,
                   e.Organiser.UserName)).ToListAsync();

            return View(events);
        }

        [HttpPost]

        public async Task<IActionResult> Join(int id)
        {
            var currentEvent = await data.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync();

            if (currentEvent == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (!currentEvent.EventsParticipants.Any(p => p.HelperId == userId))
            {
                currentEvent.EventsParticipants
                 .Add(new EventParticipant()
                 {
                     HelperId = userId,
                     EventId = id
                 });

                await data.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Joined));
        }
        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string userId = GetUserId();

            var model = await data.EventsParticipants
                .Where(ep => ep.HelperId == userId)
                .AsNoTracking()
                .Select(ep => new EventViewModel(

                    ep.EventId,
                    ep.Event.Name,
                    ep.Event.Start,
                    ep.Event.Type.Name,
                    ep.Event.Organiser.UserName
                ))
                 .ToListAsync();

            return View(model);


        }

        public async Task<IActionResult> Leave(int id)
        {
            var currentEvent = await data.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync();

            if (currentEvent == null)
            {
                return BadRequest();
            }

            var userId = GetUserId();
            var eventParticipant = currentEvent.EventsParticipants
                 .FirstOrDefault(ep => ep.HelperId == userId);

            if (eventParticipant == null)
            {
                return BadRequest();
            }

            currentEvent.EventsParticipants.Remove(eventParticipant);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));


        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new EventFormViewModel();
            model.Types = await GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormViewModel model)
        {
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            if (!DateTime.TryParseExact(model.Start,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out start))
            {
                ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be {DataConstants.DateFormat}");
            }

            if (!DateTime.TryParseExact(model.End,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out end))
            {
                ModelState.AddModelError(nameof(model.End), $"Invalid date! Format must be {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await GetTypes();
                return View(model);
            }

            var entity = new Event()
            {
                Name = model.Name,
                CreatedOn = DateTime.Now,
                Start = start,
                End = end,
                Description = model.Description,
                TypeId = model.TypeId,
                OrganiserId = GetUserId(),
            };

            await data.Events.AddAsync(entity);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var currentEvent= await data.Events.FindAsync(id);

            if(currentEvent == null)
            {
                return BadRequest();
            }

            var userId = GetUserId();

            if(userId != currentEvent.OrganiserId)
            {
                return Unauthorized();
            }

            var model = new EventFormViewModel()
            {
                Name = currentEvent.Name,
                Description = currentEvent.Description,
                Start = currentEvent.Start.ToString(DataConstants.DateFormat),
                End = currentEvent.End.ToString(DataConstants.DateFormat),
                TypeId = currentEvent.TypeId
            };
            model.Types = await GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventFormViewModel model, int id)
        {
            var currentEvent = await data.Events.FindAsync(id);

            if (currentEvent == null)
            {
                return BadRequest();
            }

            var userId = GetUserId();

            if (userId != currentEvent.OrganiserId)
            {
                return Unauthorized();
            }

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            if (!DateTime.TryParseExact(model.Start,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out start))
            {
                ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be {DataConstants.DateFormat}");
            }

            if (!DateTime.TryParseExact(model.End,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out end))
            {
                ModelState.AddModelError(nameof(model.End), $"Invalid date! Format must be {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await GetTypes();
                return View(model);
            }

            
            currentEvent.Start = start;
            currentEvent.End = end;
            currentEvent.Name = model.Name;
            currentEvent.Description = model.Description;
            currentEvent.TypeId = model.TypeId;

            await data.SaveChangesAsync();
            return RedirectToAction(nameof(All));
            
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {            
            var model = await data.Events
                .Where(e => e.Id == id)
                .AsNoTracking()
                .Select(e => new EventDetailsViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start,
                    End = e.End,
                    CreatedOn = e.CreatedOn,
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name
                }
            ).FirstOrDefaultAsync();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);

        }
        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        private async Task<IEnumerable<TypeViewModel>> GetTypes()
        {
            return await data.Types
                .AsNoTracking()
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }
    }
}
