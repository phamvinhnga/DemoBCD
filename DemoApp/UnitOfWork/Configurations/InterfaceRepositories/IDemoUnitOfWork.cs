using Demo.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.IRepositories;

namespace UnitOfWork.Configurations.InterfaceRepositories
{
    public interface IDemoUnitOfWork : IUnitOfWork
    {
        IGenericRepository<Organization> Organizations { get; init; }
        IGenericRepository<Title> Titles { get; init; }
        IGenericRepository<UserOrganization> UserOrganizations { get; init; }
    }
}
