using System.ComponentModel.DataAnnotations;

namespace crudemvccore.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual List<Category> Categories { get; set; }

    }
}
