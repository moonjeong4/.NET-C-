using Microsoft.EntityFrameworkCore;

namespace Model;
public class FireRnRContext : DbContext
{

    public virtual DbSet<User> Users
    {
        get; set;
    }

    public virtual DbSet<Address> Addresses
    {
        get; set;
    }

    public virtual DbSet<Amenity> Amenities
    {
        get; set;
    }
    public virtual DbSet<Country> Countries
    {
        get; set;
    }

    public virtual DbSet<Image> Images
    {
        get; set;
    }
    public virtual DbSet<Property> Properties
    {
        get; set;
    }

    public virtual DbSet<PropertyAmenity> PropertyAmenities
    {
        get; set;
    }

    public virtual DbSet<Rating> Ratings
    {
        get; set;
    }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseMySql("server=localhost;database=firernr_luke;user=root;password=xxxxxx;treattinyasboolean=true", ServerVersion.Parse("10.9.3-MariaDB"));
    }
}

