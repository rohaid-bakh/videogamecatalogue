using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ro_VideoGameCatalogue.Data;
using Ro_VideoGameCatalogue.Models;
using System.Data;

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


        // POST: Videogames/Pass
        [HttpPost]
        //[ValidateAntiForgeryToken] 
        //Removed it for now because I'm not sure why it's throwing errors for every valid submission
        public async Task Pass(string? title, string str_date, string? rating)
        {
            Videogame data = new Videogame();
            
            data.Title = title;
            data.ReleaseDate = DateTime.Parse(str_date);
            data.Genre = rating;
            await Create(data);
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

        // GET: Videogames/Edit
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
            return PartialView("Edit",videogame);
        }

        //POST: Videogamaes/EditPass

        [HttpPost]
        public async Task EditPass(int id, string? title, string str_date, string? rating)
        {
            Videogame data = new Videogame();

            data.Title = title;
            data.ReleaseDate = DateTime.Parse(str_date);
            data.Genre = rating;
            data.ID = id;
            await Edit(id, data);
        }
        // POST: Videogames/Edit/
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
