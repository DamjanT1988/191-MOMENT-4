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
    public class AlbumController : ControllerBase
    {
        private readonly AlbumLibraryContext _context;

        public AlbumController(AlbumLibraryContext context)
        {
            _context = context;
        }

        // GET: api/Album
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumModel>>> GetAlbumLibrary()
        {
            return await _context.AlbumLibrary.ToListAsync();
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumModel>> GetAlbumModel(int id)
        {
            var albumModel = await _context.AlbumLibrary.FindAsync(id);

            if (albumModel == null)
            {
                return NotFound();
            }

            return albumModel;
        }

        // PUT: api/Album/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbumModel(int id, AlbumModel albumModel)
        {
            if (id != albumModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(albumModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumModelExists(id))
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

        // POST: api/Album
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlbumModel>> PostAlbumModel(AlbumModel albumModel)
        {
            _context.AlbumLibrary.Add(albumModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlbumModel", new { id = albumModel.ID }, albumModel);
        }

        // DELETE: api/Album/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbumModel(int id)
        {
            var albumModel = await _context.AlbumLibrary.FindAsync(id);
            if (albumModel == null)
            {
                return NotFound();
            }

            _context.AlbumLibrary.Remove(albumModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlbumModelExists(int id)
        {
            return _context.AlbumLibrary.Any(e => e.ID == id);
        }
    }
}
