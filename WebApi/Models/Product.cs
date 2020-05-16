using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Product
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