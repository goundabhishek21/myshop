using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace crudemvccore.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        
        public string Image {  get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public string Randomstring { get; set; }
    }
   
}
