using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers.Base
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CRUDBaseController<IGenericRepository<T>> : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
