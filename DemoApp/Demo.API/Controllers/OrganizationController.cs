using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading.Tasks;
using UnitOfWork.Configurations.InterfaceRepositories;

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IDemoUnitOfWork _context;

        public OrganizationController(IDemoUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetListOrganization()
        {
            var list = await _context.Organizations.GetAllAsync();
            return Ok(list);
        }
    }
}
