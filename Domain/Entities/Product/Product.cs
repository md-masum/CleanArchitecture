using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities.Product
{
    public class Product : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Style { get; set; }
        public float Price { get; set; }
        public byte Stock { get; set; }
    }
}