using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgeBO.Models;

namespace AgeBO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildOrdersController : ControllerBase
    {
        private readonly BuildOrderContext _context;

        public BuildOrdersController(BuildOrderContext context)
        {
            _context = context;
        }

        // GET: api/BuildOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildOrder>>> GetBuildOrders()
        {
            return await _context.BuildOrders.ToListAsync();
        }

        // GET: api/BuildOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildOrder>> GetBuildOrder(long id)
        {
            var buildOrder = await _context.BuildOrders.FindAsync(id);

            if (buildOrder == null)
            {
                return NotFound();
            }

            return buildOrder;
        }

        // PUT: api/BuildOrders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuildOrder(long id, BuildOrder buildOrder)
        {
            if (id != buildOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(buildOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildOrderExists(id))
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

        // POST: api/BuildOrders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BuildOrder>> PostBuildOrder(BuildOrder buildOrder)
        {
            _context.BuildOrders.Add(buildOrder);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetBuildOrder", new { id = buildOrder.Id }, buildOrder);
            return CreatedAtAction(nameof(GetBuildOrder), new { id = buildOrder.Id }, buildOrder);
        }

        // DELETE: api/BuildOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BuildOrder>> DeleteBuildOrder(long id)
        {
            var buildOrder = await _context.BuildOrders.FindAsync(id);
            if (buildOrder == null)
            {
                return NotFound();
            }

            _context.BuildOrders.Remove(buildOrder);
            await _context.SaveChangesAsync();

            return buildOrder;
        }

        private bool BuildOrderExists(long id)
        {
            return _context.BuildOrders.Any(e => e.Id == id);
        }
    }
}
