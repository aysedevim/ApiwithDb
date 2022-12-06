using ApiwithDb.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiwithDb.Data
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {
            
        }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<City> City { get; set; }

    }
}
