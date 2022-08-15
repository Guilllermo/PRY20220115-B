using System.ComponentModel.DataAnnotations;

namespace PRY20220115.Models
{
    public class Bus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        //[Required]
        //public Administrador? Administrador { get; set; }
    }
}
