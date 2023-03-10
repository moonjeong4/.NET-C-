using D6Lab4.Model;
using Microsoft.EntityFrameworkCore;

namespace D6Lab4.DBContexts;

public class MoonLab4Context : DbContext
{

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }




    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseMySql("server=localhost;database=MoonLab4;user=xxxxxx;password=xxxx;treattinyasboolean=true",
                ServerVersion.Parse("10.9.3-mariadb"));
    }


}


