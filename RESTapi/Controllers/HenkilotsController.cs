using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTapi.Models;
using Microsoft.Extensions.Logging;

namespace RESTapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HenkilotsController : ControllerBase
    {
        private readonly ILogger<HenkilotsController> _logger;
        private readonly MittaustuloksetContext _context;

        public HenkilotsController(ILogger<HenkilotsController> logger, MittaustuloksetContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/Henkilots
        [HttpGet]
        public async Task<IEnumerable<Henkilot>> Get()
        {
            var persons = await _context.Henkilot.ToListAsync();
            return persons;
        }

        // GET: api/Henkilots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Henkilot>> Get(long id)
        {
            Henkilot henkilot = await _context.Henkilot.FirstOrDefaultAsync(i => i.Id == id);

            if (henkilot == null)
            {
                return NotFound();
            }

            return henkilot;
        }

        // PUT: api/Henkilots/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Henkilot henkilot)
        {
            if (id != henkilot.Id)
            {
                return BadRequest();
            }

            Henkilot dbHenkilot = await _context.Henkilot.FirstOrDefaultAsync(i => i.Id == id);
            if (null == dbHenkilot)
            {
                return NotFound();
            }
            dbHenkilot.Hetu = henkilot.Hetu;
            dbHenkilot.Nimi = henkilot.Nimi;
            dbHenkilot.Osoite = henkilot.Osoite;
            dbHenkilot.Puhelinnro = henkilot.Puhelinnro;
            dbHenkilot.Email = henkilot.Email;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // POST: api/Henkilots
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Henkilot>> Post([FromBody] Henkilot henkilot)
        {
            _context.Henkilot.Add(henkilot);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = henkilot.Id }, henkilot);
        }

        // DELETE: api/Henkilots/5
        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            var henkilot = await _context.Henkilot.FirstOrDefaultAsync(i => i.Id == id);
            if (henkilot != null)
            {
                _context.Henkilot.Remove(henkilot);
                await _context.SaveChangesAsync();

            }

        }    
    }
}
