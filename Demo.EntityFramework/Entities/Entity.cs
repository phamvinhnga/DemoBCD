using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.EntityFramework.Entities
{
    public class Entity<TPrimaryKey> : IEntity<TPrimaryKey> where TPrimaryKey : struct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TPrimaryKey Id { get; set; }
    }

    public interface IEntity<TPrimaryKey> where TPrimaryKey : struct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TPrimaryKey Id { get; set; }
    }
}
