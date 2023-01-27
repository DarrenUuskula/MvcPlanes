using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcPlanes.Data;
using MvcPlanes.Models;

namespace MvcPlanes.Controllers
{
    public class PlanesController : Controller
    {
        private readonly MvcPlanesContext _context;

        public string? PlanesCategory { get; private set; }

        public PlanesController(MvcPlanesContext context)
        {
            _context = context;
        }

        // GET: Planes
        public async Task<IActionResult> Index(string plane, string searchString)
        {
            // Use LINQ to get list of Categorys.
            IQueryable<string> categoryQuery = from m in _context.Planes
                                            orderby m.Category
                                            select m.Category;
            var Planes = from m in _context.Planes
                         select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                Planes = Planes.Where(s => s.Name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(PlanesCategory))
            {
                Planes = Planes.Where(x => x.Category == PlanesCategory);
            }

            var PlanesCategoryVM = new PlanesCategoryViewModel
            {
                Categorys = new SelectList(await categoryQuery.Distinct().ToListAsync()),
                Planes = await Planes.ToListAsync()
            };

            return View(PlanesCategoryVM);
        }

        // GET: Plane/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Planes == null)
            {
                return NotFound();
            }

            var Plane = await _context.Planes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Plane == null)
            {
                return NotFound();
            }

            return View(Plane);
        }

        // GET: Plane/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plane/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ReleaseDate,Category,Price,Safety")] Plane plane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plane);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Planes.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Plane/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Category,Price,Safety")] Plane planes)
        {
            if (id != planes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaneExists(planes.Id))
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
            return View(planes);
        }

        // GET: Plane/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Planes == null)
            {
                return NotFound();
            }

            var Planes = await _context.Planes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Planes == null)
            {
                return NotFound();
            }

            return View(Planes);
        }

        // POST: Plane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Planes == null)
            {
                return Problem("Entity set 'MvcPlaneContext.Plane'  is null.");
            }
            var Plane = await _context.Planes.FindAsync(id);
            if (Plane != null)
            {
                _context.Planes.Remove(Plane);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaneExists(int id)
        {
          return _context.Planes.Any(e => e.Id == id);
        }
    }
}
