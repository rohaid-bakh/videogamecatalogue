using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ro_VideoGameCatalogue.Data;
using Ro_VideoGameCatalogue.Models;

namespace Ro_VideoGameCatalogue.Controllers
{
    public class VideogamesController : Controller
    {
        private readonly MVCVideogameContext _context;

        public VideogamesController(MVCVideogameContext context)
        {
            _context = context;
        }

        // GET: Videogames
        public async Task<IActionResult> Index()
        {
            return View(await _context.Videogame.ToListAsync());
        }

        // GET: Videogames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videogame = await _context.Videogame
                .FirstOrDefaultAsync(m => m.ID == id);
            if (videogame == null)
            {
                return NotFound();
            }

            return View(videogame);
        }

        // GET: Videogames/Create
        public IActionResult Create()
        {
            return PartialView("Create");
        }

        // POST: Videogames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre")] Videogame videogame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videogame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(videogame);
        }

        // GET: Videogames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videogame = await _context.Videogame.FindAsync(id);
            if (videogame == null)
            {
                return NotFound();
            }
            return View(videogame);
        }

        // POST: Videogames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre")] Videogame videogame)
        {
            if (id != videogame.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videogame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideogameExists(videogame.ID))
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
            return View(videogame);
        }

        // GET: Videogames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videogame = await _context.Videogame
                .FirstOrDefaultAsync(m => m.ID == id);
            if (videogame == null)
            {
                return NotFound();
            }

            return View(videogame);
        }

        // POST: Videogames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var videogame = await _context.Videogame.FindAsync(id);
            if (videogame != null)
            {
                _context.Videogame.Remove(videogame);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideogameExists(int id)
        {
            return _context.Videogame.Any(e => e.ID == id);
        }
    }
}
