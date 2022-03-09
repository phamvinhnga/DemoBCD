using Demo.Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork.Configurations.InterfaceRepositories;

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrganizationController : ControllerBase
    {
        private readonly IDemoUnitOfWork _context;

        public OrganizationController(IDemoUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organization>>> GetListOrganization()
        {
            var list = await _context.Organizations.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Organization>> GetOrganization(Guid id)
        {
            var organization = await _context.Organizations.GetAsync(id);

            if (organization == null)
            {
                return NotFound();
            }

            return organization;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganization(Guid id, Organization organization)
        {
            if (id != organization.Id)
            {
                return BadRequest();
            }

            _context.Organizations.Update(organization);

            try
            {
                await _context.SaveChangeAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationExists(id))
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
        public async Task<ActionResult<Organization>> PostOrganization(Organization organization)
        {
            _context.Organizations.Add(organization);
            await _context.SaveChangeAsync();

            return CreatedAtAction("GetOrganization", new { id = organization.Id }, organization);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitle(Guid id)
        {
            var organization = await _context.Organizations.GetAsync(id);
            if (organization == null)
            {
                return NotFound();
            }

            _context.Organizations.Remove(organization.Id);
            await _context.SaveChangeAsync();

            return NoContent();
        }
        private bool OrganizationExists(Guid id)
        {
            var organization = _context.Organizations.GetAsync(id);
            if (organization == null)
                return false;
            return true;
        }
    }
}
