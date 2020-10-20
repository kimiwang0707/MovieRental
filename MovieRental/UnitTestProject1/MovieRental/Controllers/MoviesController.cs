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
    public class MoviesController : Controller
    {
        private readonly MovieRentalContext _context;

        public MoviesController(MovieRentalContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index(
            string sortOrder,
            string searchString,
            string currentFilter,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var movies = from m in _context.Movies
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    movies = movies.OrderByDescending(m => m.Title);
                    break;
                case "Date":
                    movies = movies.OrderBy(m => m.ReleaseYear);
                    break;
                case "date_desc":
                    movies = movies.OrderByDescending(m => m.ReleaseYear);
                    break;
                default:
                    movies = movies.OrderBy(m => m.Title);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<Movies>.CreateAsync(movies.AsNoTracking(), pageNumber ?? 1, pageSize));
        }        

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies
                .Include(m => m.Borrowers)
                .Include(m => m.Director)
                .SingleOrDefaultAsync(m => m.MovieId == id);
            if (movies == null)
            {
                return NotFound();
            }

            return View(movies);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            //ViewData["Cid"] = new SelectList(_context.Customers, "Cid", "Name");
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Did", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Cid,DirectorId,Title,ReleaseYear")] Movies movies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["Cid"] = new SelectList(_context.Customers, "Cid", "Name", movies.Cid);
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Did", "Name", movies.DirectorId);
            return View(movies);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies.SingleOrDefaultAsync(m => m.MovieId == id);
            if (movies == null)
            {
                return NotFound();
            }

            ViewData["Cid"] = new SelectList(_context.Customers, "Cid", "Name", movies.Cid);
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Did", "Name", movies.DirectorId);
            return View(movies);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Cid,DirectorId,Title,ReleaseYear")] Movies movies)
        {
            if (id != movies.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviesExists(movies.MovieId))
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

            ViewData["Cid"] = new SelectList(_context.Customers, "Cid", "Name", movies.Cid);
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Did", "Name", movies.DirectorId);
            return View(movies);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies
                .Include(m => m.Borrowers)
                .Include(m => m.Director)
                .SingleOrDefaultAsync(m => m.MovieId == id);
            if (movies == null)
            {
                return NotFound();
            }

            return View(movies);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movies = await _context.Movies.SingleOrDefaultAsync(m => m.MovieId == id);
            _context.Movies.Remove(movies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviesExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
