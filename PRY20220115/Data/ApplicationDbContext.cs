using Microsoft.EntityFrameworkCore;
using PRY20220115.Models;

namespace PRY20220115.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Pasajero>? Pasajeros { get; set; }
    }
}
