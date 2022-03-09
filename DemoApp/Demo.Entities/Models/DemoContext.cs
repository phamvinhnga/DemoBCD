using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entities.Models
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<UserOrganization> UserOrganizations { get; set; }        
    }
}
