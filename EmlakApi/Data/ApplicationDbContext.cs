using EmlakApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmlakApi.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Musteri>Musteris { get; set; }
    }

}
