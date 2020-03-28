using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MartialApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace MartialApp.Controllers
{
    
    [Authorize]
    public class TrainersController : Controller
    {
        private readonly BJJSchoolContext _context;

        public TrainersController(BJJSchoolContext context)
        {
            _context = context;
        }

        // GET: Trainers
        public async Task<IActionResult> Index()
        {


            return View(await _context.Trainers.ToListAsync());
        }

        // GET: Trainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainers = await _context.Trainers
                .FirstOrDefaultAsync(m => m.TrainerId == id);
            if (trainers == null)
            {
                return NotFound();
            }

            return View(trainers);
        }

        // GET: Trainers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainerId,UserName,Name,LastName,LastName2,SchoolId,BeltId,Email,Phone,Birthday,Created,Tarifa,Importe")] Trainers trainers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainers);
        }

        // GET: Trainers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainers = await _context.Trainers.FindAsync(id);
            PopulateBeltDropDownList(trainers.BeltId);
            PopulateSchoolDropDownList(trainers.SchoolId);
            if (trainers == null)
            {
                return NotFound();
            }
            return View(trainers);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrainerId,UserName,Name,LastName,LastName2,SchoolId,BeltId,Email,Phone,Birthday,Created,Tarifa,Importe")] Trainers trainers)
        {
            if (id != trainers.TrainerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainers);
                    //_context.Entry<Trainers>(trainers).Property(x => x.School).IsModified = false;
                    //_context.Entry<Trainers>(trainers).Property(x => x.Belt).IsModified = false;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainersExists(trainers.TrainerId))
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
            return View(trainers);
        }

        // GET: Trainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainers = await _context.Trainers
                .FirstOrDefaultAsync(m => m.TrainerId == id);
            if (trainers == null)
            {
                return NotFound();
            }

            return View(trainers);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainers = await _context.Trainers.FindAsync(id);
            _context.Trainers.Remove(trainers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainersExists(int id)
        {
            return _context.Trainers.Any(e => e.TrainerId == id);
        }
        private void PopulateBeltDropDownList(object selectedBelt = null)
        {
            var beltQuery = from d in _context.Belt
                                   orderby d.BeltId
                                   select d;
            ViewBag.BeltId = new SelectList(beltQuery.AsNoTracking(), "BeltId", "Colour", selectedBelt);
        }

        private void PopulateSchoolDropDownList(object selectedSchool = null)
        {
            var schoolQuery = from d in _context.School
                            orderby d.SchoolId
                            select d;
            ViewBag.SchoolId = new SelectList(schoolQuery.AsNoTracking(), "SchoolId", "NickName", selectedSchool);
        }
    }
}
