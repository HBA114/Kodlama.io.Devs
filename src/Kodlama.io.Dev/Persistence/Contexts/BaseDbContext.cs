using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> ProgrammingLanguageTechnologies { get; set; }


        public BaseDbContext(DbContextOptions<BaseDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");

                a.HasMany(p => p.Technologies);
            });

            ProgrammingLanguage[] programmingLanguageSeeds =
            {
                new (1, "Python"),
                new (2, "C++")
            };

            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageSeeds);



            modelBuilder.Entity<Technology>(a =>
            {
                a.ToTable("Technologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Description).HasColumnName("Description");

                a.HasOne(p => p.ProgrammingLanguage);
            });

            Technology[] programmingLanguageTechnologySeeds =
            {
                new(1, 1, "Flask", "Micro Web Framework"),
                new(2, 1, "Django", "Web Application Framework"),
                new(3, 2, "OpenGL", "Low-level, widely supported modeling and rendering software package.")
            };

            modelBuilder.Entity<Technology>().HasData(programmingLanguageTechnologySeeds);
        }
    }
}
