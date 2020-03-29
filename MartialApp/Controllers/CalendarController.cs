using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MartialApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace fullcalendarcore.Controllers
{
    public class CalendarController : Controller
    {

        private readonly BJJSchoolContext _context;

        public CalendarController(BJJSchoolContext context)
        {
            _context = context;
        }

        public IActionResult Index() 
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetCalendarEvents(string start, string end) {
            var events = await _context.Event.ToListAsync();

            return Json(events);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEvent([FromBody] Event evt) 
        {
            string message = String.Empty;

            _context.Update(evt);
            await _context.SaveChangesAsync();

            return Json(new { message });
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] Event evt) 
        {
            string message = String.Empty;
            int eventId = 0;

            if (ModelState.IsValid)
            {
                _context.Add(evt);
                await _context.SaveChangesAsync();
            }


            return Json(new { message, eventId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEvent([FromBody] Event evt) {
            string message = String.Empty;

            var eventFound = await _context.Event.FindAsync(evt.EventId);
            _context.Event.Remove(eventFound);
            await _context.SaveChangesAsync();

            return Json(new { message });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() 
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
