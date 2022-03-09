using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Entities.Models
{
    [Table("Organizations", Schema = "dbo")]
    public class Organization 
    {
        public Guid Id { get; set; }
        public string CodeValue { get; set; }

        public string Name { get; set; }

        public string Titles { get; set; }

        public virtual IEnumerable<UserOrganization> UserOrganizations { get; set; }
    }
}
