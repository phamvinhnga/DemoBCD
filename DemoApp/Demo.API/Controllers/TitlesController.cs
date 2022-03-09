using Demo.Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork.Configurations.InterfaceRepositories;

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TitlesController : Controller
    {
        private readonly IDemoUnitOfWork _context;

        public TitlesController(IDemoUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Title>>> GetListTitles()
        {
            var list = await _context.Titles.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Title>> GetTitle(Guid id)
        {
            var title = await _context.Titles.GetAsync(id);

            if (title == null)
            {
                return NotFound();
            }

            return title;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitle(Guid id, Title title)
        {
            if (id != title.Id)
            {
                return BadRequest();
            }

            _context.Titles.Update(title);

            try
            {
                await _context.SaveChangeAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitleExists(id))
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
        [HttpPost]
        public async Task<ActionResult<Title>> PostOrganization(Title title)
        {
            _context.Titles.Add(title);
            await _context.SaveChangeAsync();

            return CreatedAtAction("GetTitle", new { id = title.Id }, title);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitle(Guid id)
        {
            var title = await _context.Titles.GetAsync(id);
            if (title == null)
            {
                return NotFound();
            }

            _context.Titles.Remove(title.Id);
            await _context.SaveChangeAsync();

            return NoContent();
        }
        private bool TitleExists(Guid id)
        {
            var organization = _context.Titles.GetAsync(id);
            if (organization == null)
                return false;
            return true;
        }
    }
}
