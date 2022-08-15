using System.ComponentModel.DataAnnotations;

namespace PRY20220115.Models
{
    public class Administrador
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

        //[Required]
        //public Bus? Company { get; set; }        
    }
}
