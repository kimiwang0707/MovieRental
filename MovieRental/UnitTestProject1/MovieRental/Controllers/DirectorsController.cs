using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieRental.Models;

namespace MovieRental.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly MovieRentalContext _context;

        public DirectorsController(MovieRentalContext context)
        {
            _context = context;
        }

        // GET: Directors
        public async Task<IActionResult> Index(
            string sortOrder,
            string searchString,
            string currentFilter,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var directors = from c in _context.Directors
                            select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                directors = directors.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    directors = directors.OrderByDescending(s => s.Name);
                    break;
                default:
                    directors = directors.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Directors>.CreateAsync(directors.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Directors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directors = await _context.Directors
                .SingleOrDefaultAsync(m => m.Did == id);
            if (directors == null)
            {
                return NotFound();
            }

            return View(directors);
        }

        // GET: Directors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Directors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Did,Name,Gender")] Directors directors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(directors);
        }

        // GET: Directors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directors = await _context.Directors.SingleOrDefaultAsync(m => m.Did == id);
            if (directors == null)
            {
                return NotFound();
            }
            return View(directors);
        }

        // POST: Directors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Did,Name,Gender")] Directors directors)
        {
            if (id != directors.Did)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectorsExists(directors.Did))
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
            return View(directors);
        }

        // GET: Directors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directors = await _context.Directors
                .SingleOrDefaultAsync(m => m.Did == id);
            if (directors == null)
            {
                return NotFound();
            }

            return View(directors);
        }

        // POST: Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directors = await _context.Directors.SingleOrDefaultAsync(m => m.Did == id);
            _context.Directors.Remove(directors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectorsExists(int id)
        {
            return _context.Directors.Any(e => e.Did == id);
        }
    }
}
