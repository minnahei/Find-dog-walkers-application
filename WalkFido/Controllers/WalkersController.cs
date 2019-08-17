using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WalkFido.Data;
using WalkFido.Models;



namespace WalkFido.Controllers
{
    public class WalkersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public WalkersController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Walkers
        public async Task<IActionResult> Index(string search)
        {
            //if (search != null)
            //{
            //    List<Walker> walker = _context.Walker.Include(w => w.User).Where(x => x.Area.Contains(search)).ToList();
            //    return View(walker);
            //}//var applicationDbContext = _context.Walker.Include(w => w.User).Where(x=>x.Area.Contains(search);

            //List<Availability> availabilities = await _context.Availability.Include(w => w.Walker).ThenInclude(x => x.User).ToListAsync();
            //return View(availabilities);

            if (search != null)
            {
                //List<Availability> availabilities = await _context.Availability.Include(w => w.Walker).Where(x => x.Area.Contains(search)).ThenInclude(x => x.User).ToListAsync();
                List<Walker> walkers = await _context.Walker.Include(x => x.Availabilities).Include(x => x.User).Where(x => x.Area.Contains(search)).ToListAsync();
                return View(walkers);

            } var applicationDbContext = _context.Walker.Include(w => w.Availabilities).Where(x => x.Area.Contains(search));
            return View(await applicationDbContext.ToListAsync());

        }

        // GET: Walkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walker = await _context.Walker
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (walker == null)
            {
                return NotFound();
            }

            return View(walker);
        }

        // GET: Walkers/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Walkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AppUserId,Availability,Area")] Walker walker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(walker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", walker.AppUserId);
            return View(walker);
        }

        // GET: Walkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walker = await _context.Walker.FindAsync(id);
            if (walker == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", walker.AppUserId);
            return View(walker);
        }

        // POST: Walkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AppUserId,Availability,Area")] Walker walker)
        {
            if (id != walker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(walker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WalkerExists(walker.Id))
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", walker.AppUserId);
            return View(walker);
        }

        // GET: Walkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walker = await _context.Walker
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (walker == null)
            {
                return NotFound();
            }

            return View(walker);
        }


        // POST: Walkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var walker = await _context.Walker.FindAsync(id);
            _context.Walker.Remove(walker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WalkerExists(int id)
        {
            return _context.Walker.Any(e => e.Id == id);
        }


        public async Task<IActionResult> Book(int id)
        {

            //AppUser user = await _userManager.FindByEmailAsync(User.Identity.Name);
            Availability availability = await _context.Availability.Where(x => x.Id== id).FirstOrDefaultAsync();



            availability.Available = false;
            _context.Update(availability);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }




}

