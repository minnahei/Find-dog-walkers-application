using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WalkFido.Data;
using WalkFido.Models;

namespace WalkFido.Controllers
{
    public class DogWalkersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DogWalkersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DogWalkers
        public async Task<IActionResult> Index()
        {
            return View(await _context.DogWalker.ToListAsync());
        }

        // GET: DogWalkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogWalker = await _context.DogWalker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dogWalker == null)
            {
                return NotFound();
            }

            return View(dogWalker);
        }

        // GET: DogWalkers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DogWalkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] DogWalker dogWalker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dogWalker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dogWalker);
        }

        // GET: DogWalkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogWalker = await _context.DogWalker.FindAsync(id);
            if (dogWalker == null)
            {
                return NotFound();
            }
            return View(dogWalker);
        }

        // POST: DogWalkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] DogWalker dogWalker)
        {
            if (id != dogWalker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dogWalker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DogWalkerExists(dogWalker.Id))
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
            return View(dogWalker);
        }

        // GET: DogWalkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogWalker = await _context.DogWalker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dogWalker == null)
            {
                return NotFound();
            }

            return View(dogWalker);
        }

        // POST: DogWalkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dogWalker = await _context.DogWalker.FindAsync(id);
            _context.DogWalker.Remove(dogWalker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DogWalkerExists(int id)
        {
            return _context.DogWalker.Any(e => e.Id == id);
        }
    }
}
