using Demo.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork.Configurations.InterfaceRepositories;
using UnitOfWork.Repositories;

namespace Demo.API.Controllers.Base
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CRUDBaseController<T> : ControllerBase where T : IDemoUnitOfWork
    {
        private readonly IDemoUnitOfWork demoUnitOfWork;          
        public CRUDBaseController(IDemoUnitOfWork demoUnitOfWork)
        {
            this.demoUnitOfWork = demoUnitOfWork;
        }       
    }
}
