using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crud7.Models;

namespace WebApplication39.Controllers
{
    public class CrudsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CrudsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cruds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Crud.ToListAsync());
        }

        // GET: Cruds/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crud = await _context.Crud
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crud == null)
            {
                return NotFound();
            }

            return View(crud);
        }

        // GET: Cruds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cruds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Emial")] Crud crud)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crud);
        }

        // GET: Cruds/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crud = await _context.Crud.FindAsync(id);
            if (crud == null)
            {
                return NotFound();
            }
            return View(crud);
        }

        // POST: Cruds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Emial")] Crud crud)
        {
            if (id != crud.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrudExists(crud.Id))
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
            return View(crud);
        }

        // GET: Cruds/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crud = await _context.Crud
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crud == null)
            {
                return NotFound();
            }

            return View(crud);
        }

        // POST: Cruds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var crud = await _context.Crud.FindAsync(id);
            if (crud != null)
            {
                _context.Crud.Remove(crud);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CrudExists(string id)
        {
            return _context.Crud.Any(e => e.Id == id);
        }
    }
}
