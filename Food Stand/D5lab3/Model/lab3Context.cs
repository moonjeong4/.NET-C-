using Microsoft.EntityFrameworkCore;

namespace D5Lab3.Model;

public partial class lab3Context : DbContext
{




    public virtual DbSet<Customer> Customers { get; set; } = null!;
    public virtual DbSet<Menu> Menus { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseMySql("server=localhost;database=lab3;user=root;password=xxxxxx;treattinyasboolean=true", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.9.3-mariadb"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("customer");

            entity.HasIndex(e => e.FavouriteItem, "customer_FK");

            entity.Property(e => e.CustomerId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("customer_id");

            entity.Property(e => e.CustomerPhoto)
                .HasMaxLength(100)
                .HasColumnName("customer_photo");

            entity.Property(e => e.FavouriteItem)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("favourite_item");

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");

            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");

            entity.HasOne(d => d.FavouriteItemNavigation)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.FavouriteItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customer_FK");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("menu");

            entity.Property(e => e.MenuId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("menu_id");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");

            entity.Property(e => e.MenuPhoto)
                .HasMaxLength(100)
                .HasColumnName("menu_photo");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.Property(e => e.Price)
                .HasPrecision(8, 2)
                .HasColumnName("price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
