using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcTask.Models;
using MvcTask.Services;

namespace MvcTask.Controllers
{
    public class TaskListController : Controller
    {
        private readonly TaskService _taskService;

        public TaskListController(TaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: TaskList
        public async Task<IActionResult> Index()
        {
            return View(await _taskService.GetAllAsync());
        }

        // GET: TaskList/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskItem = await _taskService.GetAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            return View(taskItem);
        }

        // GET: TaskList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,TaskTitle,StartDate,EndDate")] TaskItem taskItem
        )
        {
            if (ModelState.IsValid)
            {
                await _taskService.CreateAsync(taskItem);
                return RedirectToAction(nameof(Index));
            }
            return View(taskItem);
        }

        // GET: TaskList/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskItem = await _taskService.GetAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            return View(taskItem);
        }

        // POST: TaskList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            string id,
            [Bind("Id,TaskTitle,StartDate,EndDate")] TaskItem taskItem
        )
        {
            if (id != taskItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _taskService.UpdateAsync(id, taskItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var task = await _taskService.GetAsync(id);
                    if (task == null)
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(taskItem);
        }

        // GET: TaskList/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskItem = await _taskService.GetAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            return View(taskItem);
        }

        // POST: TaskList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _taskService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
