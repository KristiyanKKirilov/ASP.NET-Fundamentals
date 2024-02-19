﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public TaskController(TaskBoardAppDbContext context)
        {
            data = context;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new TaskFormViewModel();
            model.Boards = await GetBoards();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormViewModel model)
        {
            if(!(await GetBoards()).Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), ErrorMessages.InvalidBoardError);
            }
            if(ModelState.IsValid == false)
            {
                model.Boards = await GetBoards();
                return View(model);
            }

            var entity = new Data.Models.Task()
            {
                BoardId = model.BoardId,
                CreatedOn = DateTime.Now,
                Description = model.Description,
                OwnerId = GetUserId(),
                Title = model.Title
            };

            await data.AddAsync(entity);
            await data.SaveChangesAsync();

            return RedirectToAction("Index", "Board");

        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var task = await data.Tasks
                .Where(b => b.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Description = t.Description,
                    Board = t.Board.Name,
                    CreatedOn = t.CreatedOn != null && t.CreatedOn.HasValue 
                    ? t.CreatedOn.Value.ToString("dd.MM.yyyy HH:mm") 
                    : "",
                    Owner = t.Owner.UserName, 
                    Title = t.Title
                })
                .FirstOrDefaultAsync();

            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await data.Tasks.FindAsync(id);

            if(task == null)
            {
                return BadRequest();
            }

            if(task.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new TaskFormViewModel()
            {
                Id = task.Id,
                Description = task.Description,
                Title = task.Title,
                BoardId = task.BoardId,
                Boards = await GetBoards()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskFormViewModel model, int id)
        {
            var task = await data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            if(task.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            if (!(await GetBoards()).Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), ErrorMessages.InvalidBoardError);
            }

            if (!ModelState.IsValid)
            {
                model.Boards = await GetBoards();
                return View(model);
            }

            task.Title = model.Title;
            task.Description = model.Description;
            task.BoardId = model.BoardId;

            await data.SaveChangesAsync();
            return RedirectToAction("Index", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await data.Tasks.FindAsync(id);

            if(task == null)
            {
                return BadRequest();
            }

            if(task.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel model)
        {
            var task = await data.Tasks.FindAsync(model.Id);

            if(task == null)
            {
                return BadRequest();
            }

            if (task.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            data.Remove(task);
            await data.SaveChangesAsync();

            return RedirectToAction("Index", "Board");
        }

        private string GetUserId() 
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        private async Task<IEnumerable<TaskBoardViewModel>> GetBoards()
        {
            return await data.Boards.Select(b => new TaskBoardViewModel
            {
                Id = b.Id,
                Name = b.Name,
            }).ToListAsync();
        }
    }
}
