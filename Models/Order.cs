using Microsoft.AspNetCore.Identity;

namespace crudemvccore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public IdentityUser User { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Contact {  get; set; }
        public string Email { get; set; }
        public List<Orderproduct> Orderproducts { get; set; }
    }
}
