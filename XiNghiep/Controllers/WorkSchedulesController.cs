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
    public class WorkSchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkSchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkSchedules
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WorkSchedules.Include(w => w.Employee).Include(w => w.Shift);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WorkSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workSchedule = await _context.WorkSchedules
                .Include(w => w.Employee)
                .Include(w => w.Shift)
                .FirstOrDefaultAsync(m => m.WorkScheduleId == id);
            if (workSchedule == null)
            {
                return NotFound();
            }

            return View(workSchedule);
        }

        // GET: WorkSchedules/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "ShiftId", "ShiftId");
            return View();
        }

        // POST: WorkSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkScheduleId,EmployeeId,WorkDate,StartDate,EndDate,ShiftId,CreateAt")] WorkSchedule workSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", workSchedule.EmployeeId);
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "ShiftId", "ShiftId", workSchedule.ShiftId);
            return View(workSchedule);
        }

        // GET: WorkSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workSchedule = await _context.WorkSchedules.FindAsync(id);
            if (workSchedule == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", workSchedule.EmployeeId);
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "ShiftId", "ShiftId", workSchedule.ShiftId);
            return View(workSchedule);
        }

        // POST: WorkSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkScheduleId,EmployeeId,WorkDate,StartDate,EndDate,ShiftId,CreateAt")] WorkSchedule workSchedule)
        {
            if (id != workSchedule.WorkScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkScheduleExists(workSchedule.WorkScheduleId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", workSchedule.EmployeeId);
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "ShiftId", "ShiftId", workSchedule.ShiftId);
            return View(workSchedule);
        }

        // GET: WorkSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workSchedule = await _context.WorkSchedules
                .Include(w => w.Employee)
                .Include(w => w.Shift)
                .FirstOrDefaultAsync(m => m.WorkScheduleId == id);
            if (workSchedule == null)
            {
                return NotFound();
            }

            return View(workSchedule);
        }

        // POST: WorkSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workSchedule = await _context.WorkSchedules.FindAsync(id);
            if (workSchedule != null)
            {
                _context.WorkSchedules.Remove(workSchedule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkScheduleExists(int id)
        {
            return _context.WorkSchedules.Any(e => e.WorkScheduleId == id);
        }
    }
}
