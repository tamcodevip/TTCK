﻿using System;
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
    public class RolePermissionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RolePermissionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RolePermissions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RolePermissions.Include(r => r.Role);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RolePermissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolePermission = await _context.RolePermissions
                .Include(r => r.Role)
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (rolePermission == null)
            {
                return NotFound();
            }

            return View(rolePermission);
        }

        // GET: RolePermissions/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId");
            return View();
        }

        // POST: RolePermissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,Permission")] RolePermission rolePermission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rolePermission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", rolePermission.RoleId);
            return View(rolePermission);
        }

        // GET: RolePermissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolePermission = await _context.RolePermissions.FindAsync(id);
            if (rolePermission == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", rolePermission.RoleId);
            return View(rolePermission);
        }

        // POST: RolePermissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleId,Permission")] RolePermission rolePermission)
        {
            if (id != rolePermission.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolePermission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolePermissionExists(rolePermission.RoleId))
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", rolePermission.RoleId);
            return View(rolePermission);
        }

        // GET: RolePermissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolePermission = await _context.RolePermissions
                .Include(r => r.Role)
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (rolePermission == null)
            {
                return NotFound();
            }

            return View(rolePermission);
        }

        // POST: RolePermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rolePermission = await _context.RolePermissions.FindAsync(id);
            if (rolePermission != null)
            {
                _context.RolePermissions.Remove(rolePermission);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolePermissionExists(int id)
        {
            return _context.RolePermissions.Any(e => e.RoleId == id);
        }
    }
}
