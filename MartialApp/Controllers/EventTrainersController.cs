using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MartialApp.Models;

namespace MartialApp.Controllers
{
    public class EventTrainersController : Controller
    {
        private readonly BJJSchoolContext _context;

        public EventTrainersController(BJJSchoolContext context)
        {
            _context = context;
        }

        // GET: EventTrainers
        public async Task<IActionResult> Index()
        {
            var bJJSchoolContext = _context.EventTrainer.Include(e => e.Event).Include(e => e.Trainers);
            return View(await bJJSchoolContext.ToListAsync());
        }

        // GET: EventTrainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventTrainer = await _context.EventTrainer
                .Include(e => e.Event)
                .Include(e => e.Trainers)
                .FirstOrDefaultAsync(m => m.EventTrainerId == id);
            if (eventTrainer == null)
            {
                return NotFound();
            }

            return View(eventTrainer);
        }

        // GET: EventTrainers/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventId");
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerId");
            return View();
        }

        // POST: EventTrainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventTrainerId,TrainerId,EventId")] EventTrainer eventTrainer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventTrainer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventId", eventTrainer.EventId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerId", eventTrainer.TrainerId);
            return View(eventTrainer);
        }

        // GET: EventTrainers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventTrainer = await _context.EventTrainer.FindAsync(id);
            if (eventTrainer == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventId", eventTrainer.EventId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerId", eventTrainer.TrainerId);
            return View(eventTrainer);
        }

        // POST: EventTrainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventTrainerId,TrainerId,EventId")] EventTrainer eventTrainer)
        {
            if (id != eventTrainer.EventTrainerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventTrainer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventTrainerExists(eventTrainer.EventTrainerId))
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
            ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventId", eventTrainer.EventId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerId", eventTrainer.TrainerId);
            return View(eventTrainer);
        }

        // GET: EventTrainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventTrainer = await _context.EventTrainer
                .Include(e => e.Event)
                .Include(e => e.Trainers)
                .FirstOrDefaultAsync(m => m.EventTrainerId == id);
            if (eventTrainer == null)
            {
                return NotFound();
            }

            return View(eventTrainer);
        }

        // POST: EventTrainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventTrainer = await _context.EventTrainer.FindAsync(id);
            _context.EventTrainer.Remove(eventTrainer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventTrainerExists(int id)
        {
            return _context.EventTrainer.Any(e => e.EventTrainerId == id);
        }
    }
}
