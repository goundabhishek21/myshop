using System.ComponentModel.DataAnnotations;

namespace crudemvccore.Models
{
    public class Todotask
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsComplete { get; set; }

    }
}
