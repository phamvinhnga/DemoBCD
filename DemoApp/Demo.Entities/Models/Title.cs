using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Entities.Models
{
    [Table("Titles", Schema = "dbo")]
    public class Title
    {
        public Guid Id { get; set; }
        public string CodeValue { get; set; }

        public string Name { get; set; }
    }
}
