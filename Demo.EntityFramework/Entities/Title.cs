using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.EntityFramework.Entities
{
    [Table("Titles", Schema = "dbo")]
    public class Title : Entity<Guid>
    {
        public string CodeValue { get; set; }

        public string Name { get; set; }
    }
}
