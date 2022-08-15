using System.ComponentModel.DataAnnotations;

namespace PRY20220115.Models
{
    public class Pasajero
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Mail { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }
    }
}
