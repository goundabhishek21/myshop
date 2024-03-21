using crudemvccore.Models;
using System.ComponentModel.DataAnnotations;

namespace crudemvccore.ViewModel
{
    public class CheckoutViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Contact {  get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string PinCode { get; set; }
        public virtual List<Cart> Carts { get; set; }
      
    }
}
