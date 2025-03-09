using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XiNghiep.Data;
using XiNghiep.Models;

namespace XiNghiep.Controllers
{
    public class TaskProgressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskProgressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaskProgresses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TaskProgresses.Include(t => t.Task);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TaskProgresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskProgress = await _context.TaskProgresses
                .Include(t => t.Task)
                .FirstOrDefaultAsync(m => m.ProgressId == id);
            if (taskProgress == null)
            {
                return NotFound();
            }

            return View(taskProgress);
        }

        // GET: TaskProgresses/Create
        public IActionResult Create()
        {
            ViewData["TaskId"] = new SelectList(_context.Tasks, "TaskId", "TaskId");
            return View();
        }

        // POST: TaskProgresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgressId,TaskId,Status,UpdateNote,UpdatedAt")] TaskProgress taskProgress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskProgress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaskId"] = new SelectList(_context.Tasks, "TaskId", "TaskId", taskProgress.TaskId);
            return View(taskProgress);
        }

        // GET: TaskProgresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskProgress = await _context.TaskProgresses.FindAsync(id);
            if (taskProgress == null)
            {
                return NotFound();
            }
            ViewData["TaskId"] = new SelectList(_context.Tasks, "TaskId", "TaskId", taskProgress.TaskId);
            return View(taskProgress);
        }

        // POST: TaskProgresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgressId,TaskId,Status,UpdateNote,UpdatedAt")] TaskProgress taskProgress)
        {
            if (id != taskProgress.ProgressId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskProgress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskProgressExists(taskProgress.ProgressId))
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
            ViewData["TaskId"] = new SelectList(_context.Tasks, "TaskId", "TaskId", taskProgress.TaskId);
            return View(taskProgress);
        }

        // GET: TaskProgresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskProgress = await _context.TaskProgresses
                .Include(t => t.Task)
                .FirstOrDefaultAsync(m => m.ProgressId == id);
            if (taskProgress == null)
            {
                return NotFound();
            }

            return View(taskProgress);
        }

        // POST: TaskProgresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskProgress = await _context.TaskProgresses.FindAsync(id);
            if (taskProgress != null)
            {
                _context.TaskProgresses.Remove(taskProgress);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskProgressExists(int id)
        {
            return _context.TaskProgresses.Any(e => e.ProgressId == id);
        }
    }
}
