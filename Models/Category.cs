using System.ComponentModel.DataAnnotations;

namespace crudemvccore.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        public int? SubCategoryId {  get; set; }
        public Subcategory SubCategory { get; set; }
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
