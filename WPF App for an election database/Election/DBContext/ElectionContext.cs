using Microsoft.EntityFrameworkCore;

namespace Election.DBContext;

public class ElectionContext : DbContext
{

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<Riding> Ridings { get; set; }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Party> Parties { get; set; }

    public virtual DbSet<Vote> Votes { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseMySql("server=localhost;database=MoonQuiz2;user=xxxxxx;password=xxxxxx;treattinyasboolean=true",
                ServerVersion.Parse("10.9.3-mariadb"));
    }

}
