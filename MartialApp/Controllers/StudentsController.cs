using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MartialApp.Models;

namespace MartialApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly BJJSchoolContext _context;

        public StudentsController(BJJSchoolContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainers>>> GetTrainers()
        {
            return await _context.Trainers.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trainers>> GetTrainers(int id)
        {
            var trainers = await _context.Trainers.FindAsync(id);

            if (trainers == null)
            {
                return NotFound();
            }

            return trainers;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainers(int id, Trainers trainers)
        {
            if (id != trainers.TrainerId)
            {
                return BadRequest();
            }

            _context.Entry(trainers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Trainers>> PostTrainers(Trainers trainers)
        {
            _context.Trainers.Add(trainers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainers", new { id = trainers.TrainerId }, trainers);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Trainers>> DeleteTrainers(int id)
        {
            var trainers = await _context.Trainers.FindAsync(id);
            if (trainers == null)
            {
                return NotFound();
            }

            _context.Trainers.Remove(trainers);
            await _context.SaveChangesAsync();

            return trainers;
        }

        private bool TrainersExists(int id)
        {
            return _context.Trainers.Any(e => e.TrainerId == id);
        }
    }
}
