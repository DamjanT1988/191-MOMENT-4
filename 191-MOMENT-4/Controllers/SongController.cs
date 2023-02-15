using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _191_MOMENT_4.Data;
using _191_MOMENT_4.Model;

namespace _191_MOMENT_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly SongLibraryContext _context;

        public SongController(SongLibraryContext context)
        {
            _context = context;
        }

        // GET: api/Song
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongModel>>> GetSongLibrary()
        {
            return await _context.SongLibrary.ToListAsync();
        }

        // GET: api/Song/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongModel>> GetSongModel(int id)
        {
            var songModel = await _context.SongLibrary.FindAsync(id);

            if (songModel == null)
            {
                return NotFound();
            }

            return songModel;
        }

        // PUT: api/Song/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongModel(int id, SongModel songModel)
        {
            if (id != songModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(songModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongModelExists(id))
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

        // POST: api/Song
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SongModel>> PostSongModel(SongModel songModel)
        {
            _context.SongLibrary.Add(songModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongModel", new { id = songModel.ID }, songModel);
        }

        // DELETE: api/Song/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSongModel(int id)
        {
            var songModel = await _context.SongLibrary.FindAsync(id);
            if (songModel == null)
            {
                return NotFound();
            }

            _context.SongLibrary.Remove(songModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongModelExists(int id)
        {
            return _context.SongLibrary.Any(e => e.ID == id);
        }
    }
}
