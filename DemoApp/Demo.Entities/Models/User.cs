using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Entities.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(64)]
        public virtual string Surname { get; set; }

        [Required]
        [StringLength(64)]
        public virtual string Name { get; set; }

    }
}
