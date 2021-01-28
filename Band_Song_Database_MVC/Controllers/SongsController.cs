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
    public class SongsController : Controller
    {
        private readonly Band_Song_Database_DBContext _context;

        public SongsController(Band_Song_Database_DBContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: Songs
        public async Task<IActionResult> Index()
        {
            var band_Song_Database_DBContext = _context.Song.Include(s => s.Album).Include(s => s.MusicBand).Include(s => s.Producer);
            return View(await band_Song_Database_DBContext.ToListAsync());
        }
        [Authorize]
        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .Include(s => s.Album)
                .Include(s => s.MusicBand)
                .Include(s => s.Producer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }
        [Authorize]
        // GET: Songs/Create
        public IActionResult Create()
        {
            ViewData["AlbumId"] = new SelectList(_context.Album, "Id", "Id");
            ViewData["MusicBandId"] = new SelectList(_context.MusicBand, "Id", "Id");
            ViewData["ProducerId"] = new SelectList(_context.Producer, "Id", "Id");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,AlbumId,MusicBandId,ProducerId")] Song song)
        {
            if (ModelState.IsValid)
            {
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlbumId"] = new SelectList(_context.Album, "Id", "Id", song.AlbumId);
            ViewData["MusicBandId"] = new SelectList(_context.MusicBand, "Id", "Id", song.MusicBandId);
            ViewData["ProducerId"] = new SelectList(_context.Producer, "Id", "Id", song.ProducerId);
            return View(song);
        }
        [Authorize]
        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            ViewData["AlbumId"] = new SelectList(_context.Album, "Id", "Id", song.AlbumId);
            ViewData["MusicBandId"] = new SelectList(_context.MusicBand, "Id", "Id", song.MusicBandId);
            ViewData["ProducerId"] = new SelectList(_context.Producer, "Id", "Id", song.ProducerId);
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,AlbumId,MusicBandId,ProducerId")] Song song)
        {
            if (id != song.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.Id))
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
            ViewData["AlbumId"] = new SelectList(_context.Album, "Id", "Id", song.AlbumId);
            ViewData["MusicBandId"] = new SelectList(_context.MusicBand, "Id", "Id", song.MusicBandId);
            ViewData["ProducerId"] = new SelectList(_context.Producer, "Id", "Id", song.ProducerId);
            return View(song);
        }
        [Authorize]
        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .Include(s => s.Album)
                .Include(s => s.MusicBand)
                .Include(s => s.Producer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var song = await _context.Song.FindAsync(id);
            _context.Song.Remove(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(int id)
        {
            return _context.Song.Any(e => e.Id == id);
        }
    }
}
