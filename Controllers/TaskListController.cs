using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTask.Data;
using MvcTask.Models;

namespace MvcTask.Controllers
{
    public class TaskListController : Controller
    {
        private readonly MvcTaskItemContext _context;

        public TaskListController(MvcTaskItemContext context)
        {
            _context = context;
        }

        // GET: TaskList
        public async Task<IActionResult> Index()
        {
              return _context.TaskItem != null ? 
                          View(await _context.TaskItem.ToListAsync()) :
                          Problem("Entity set 'MvcTaskItemContext.TaskItem'  is null.");
        }

        // GET: TaskList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TaskItem == null)
            {
                return NotFound();
            }

            var taskItem = await _context.TaskItem
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Id,TaskTitle,StartDate,EndDate")] TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskItem);
        }

        // GET: TaskList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TaskItem == null)
            {
                return NotFound();
            }

            var taskItem = await _context.TaskItem.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskTitle,StartDate,EndDate")] TaskItem taskItem)
        {
            if (id != taskItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskItemExists(taskItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(taskItem);
        }

        // GET: TaskList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TaskItem == null)
            {
                return NotFound();
            }

            var taskItem = await _context.TaskItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskItem == null)
            {
                return NotFound();
            }

            return View(taskItem);
        }

        // POST: TaskList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TaskItem == null)
            {
                return Problem("Entity set 'MvcTaskItemContext.TaskItem'  is null.");
            }
            var taskItem = await _context.TaskItem.FindAsync(id);
            if (taskItem != null)
            {
                _context.TaskItem.Remove(taskItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskItemExists(int id)
        {
          return (_context.TaskItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
