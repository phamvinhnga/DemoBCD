using Demo.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Configurations.InterfaceRepositories;
using UnitOfWork.IRepositories;
using UnitOfWork.Repositories;

namespace UnitOfWork.Configurations.ClassRepositories
{
    public class DemoUnitOfWork : UnitOfWork<DemoContext>, IDemoUnitOfWork
    {
        public DemoUnitOfWork(DemoContext context) : base(context)
        {
            Organizations = new GenericRepository<Organization, DemoContext>(context);
            Titles = new GenericRepository<Title, DemoContext>(context);
            UserOrganizations = new GenericRepository<UserOrganization, DemoContext>(context);
        }

        public IGenericRepository<Organization> Organizations { get; init; }
        public IGenericRepository<Title> Titles { get; init; }
        public IGenericRepository<UserOrganization> UserOrganizations { get; init; }        
    }
}
