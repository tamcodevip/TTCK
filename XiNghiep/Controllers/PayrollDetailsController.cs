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
    public class PayrollDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PayrollDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PayrollDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PayrollDetails.Include(p => p.Payroll);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PayrollDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payrollDetail = await _context.PayrollDetails
                .Include(p => p.Payroll)
                .FirstOrDefaultAsync(m => m.PayrollDetailId == id);
            if (payrollDetail == null)
            {
                return NotFound();
            }

            return View(payrollDetail);
        }

        // GET: PayrollDetails/Create
        public IActionResult Create()
        {
            ViewData["PayrollId"] = new SelectList(_context.Payrolls, "PayrollId", "PayrollId");
            return View();
        }

        // POST: PayrollDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PayrollDetailId,PayrollId,ItemName,Amount,Type")] PayrollDetail payrollDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payrollDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PayrollId"] = new SelectList(_context.Payrolls, "PayrollId", "PayrollId", payrollDetail.PayrollId);
            return View(payrollDetail);
        }

        // GET: PayrollDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payrollDetail = await _context.PayrollDetails.FindAsync(id);
            if (payrollDetail == null)
            {
                return NotFound();
            }
            ViewData["PayrollId"] = new SelectList(_context.Payrolls, "PayrollId", "PayrollId", payrollDetail.PayrollId);
            return View(payrollDetail);
        }

        // POST: PayrollDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PayrollDetailId,PayrollId,ItemName,Amount,Type")] PayrollDetail payrollDetail)
        {
            if (id != payrollDetail.PayrollDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payrollDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayrollDetailExists(payrollDetail.PayrollDetailId))
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
            ViewData["PayrollId"] = new SelectList(_context.Payrolls, "PayrollId", "PayrollId", payrollDetail.PayrollId);
            return View(payrollDetail);
        }

        // GET: PayrollDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payrollDetail = await _context.PayrollDetails
                .Include(p => p.Payroll)
                .FirstOrDefaultAsync(m => m.PayrollDetailId == id);
            if (payrollDetail == null)
            {
                return NotFound();
            }

            return View(payrollDetail);
        }

        // POST: PayrollDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payrollDetail = await _context.PayrollDetails.FindAsync(id);
            if (payrollDetail != null)
            {
                _context.PayrollDetails.Remove(payrollDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PayrollDetailExists(int id)
        {
            return _context.PayrollDetails.Any(e => e.PayrollDetailId == id);
        }
    }
}
