﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubscribesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Subscribes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscribe>>> GetSubscribe()
        {
            return await _context.Subscribe.ToListAsync();
        }

        // GET: api/Subscribes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subscribe>> GetSubscribe(int id)
        {
            var subscribe = await _context.Subscribe.FindAsync(id);

            if (subscribe == null)
            {
                return NotFound();
            }

            return subscribe;
        }

        // PUT: api/Subscribes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscribe(int id, Subscribe subscribe)
        {
            if (id != subscribe.Id)
            {
                return BadRequest();
            }

            _context.Entry(subscribe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscribeExists(id))
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

        // POST: api/Subscribes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subscribe>> PostSubscribe(Subscribe subscribe)
        {
            _context.Subscribe.Add(subscribe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscribe", new { id = subscribe.Id }, subscribe);
        }

        // DELETE: api/Subscribes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscribe(int id)
        {
            var subscribe = await _context.Subscribe.FindAsync(id);
            if (subscribe == null)
            {
                return NotFound();
            }

            _context.Subscribe.Remove(subscribe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscribeExists(int id)
        {
            return _context.Subscribe.Any(e => e.Id == id);
        }
    }
}
