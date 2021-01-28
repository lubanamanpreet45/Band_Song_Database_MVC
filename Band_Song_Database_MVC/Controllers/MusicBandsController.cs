using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Band_Song_Database_MVC.Data;
using Band_Song_Database_MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace Band_Song_Database_MVC.Controllers
{
    public class MusicBandsController : Controller
    {
        private readonly Band_Song_Database_DBContext _context;

        public MusicBandsController(Band_Song_Database_DBContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: MusicBands
        public async Task<IActionResult> Index()
        {
            return View(await _context.MusicBand.ToListAsync());
        }
        [Authorize]
        // GET: MusicBands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicBand = await _context.MusicBand
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicBand == null)
            {
                return NotFound();
            }

            return View(musicBand);
        }
        [Authorize]
        // GET: MusicBands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MusicBands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Established")] MusicBand musicBand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musicBand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(musicBand);
        }
        [Authorize]
        // GET: MusicBands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicBand = await _context.MusicBand.FindAsync(id);
            if (musicBand == null)
            {
                return NotFound();
            }
            return View(musicBand);
        }

        // POST: MusicBands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Established")] MusicBand musicBand)
        {
            if (id != musicBand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musicBand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicBandExists(musicBand.Id))
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
            return View(musicBand);
        }
        [Authorize]
        // GET: MusicBands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicBand = await _context.MusicBand
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicBand == null)
            {
                return NotFound();
            }

            return View(musicBand);
        }

        // POST: MusicBands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musicBand = await _context.MusicBand.FindAsync(id);
            _context.MusicBand.Remove(musicBand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicBandExists(int id)
        {
            return _context.MusicBand.Any(e => e.Id == id);
        }
    }
}
