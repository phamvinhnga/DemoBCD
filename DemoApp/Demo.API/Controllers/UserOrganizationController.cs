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
    public class UserOrganizationController : ControllerBase
    {
        private readonly IDemoUnitOfWork _context;

        public UserOrganizationController(IDemoUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOrganization>>> GetListUserOrganization()
        {
            var list = await _context.UserOrganizations.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserOrganization>> GetUserOrganization(Guid id)
        {
            var userOrganization = await _context.UserOrganizations.GetAsync(id);

            if (userOrganization == null)
            {
                return NotFound();
            }

            return userOrganization;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserOrganization(Guid id, UserOrganization userOrganization)
        {
            if (id != userOrganization.Id)
            {
                return BadRequest();
            }

            _context.UserOrganizations.Update(userOrganization);

            try
            {
                await _context.SaveChangeAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserOrganizationExists(id))
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
        public async Task<ActionResult<Organization>> PostUserOrganization(UserOrganization userOrganization)
        {
            _context.UserOrganizations.Add(userOrganization);
            await _context.SaveChangeAsync();

            return CreatedAtAction("GetUserOrganization", new { id = userOrganization.Id }, userOrganization);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserOrganization(Guid id)
        {
            var userOrganization = await _context.UserOrganizations.GetAsync(id);
            if (userOrganization == null)
            {
                return NotFound();
            }

            _context.UserOrganizations.Remove(userOrganization.Id);
            await _context.SaveChangeAsync();

            return NoContent();
        }
        private bool UserOrganizationExists(Guid id)
        {
            var userOrganization = _context.UserOrganizations.GetAsync(id);
            if (userOrganization == null)
                return false;
            return true;
        }
    }
}
