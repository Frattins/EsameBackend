using EsameBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EsameBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Anagrafica> Anagrafiche { get; set; }
        public DbSet<TipoViolazione> TipoViolazioni { get; set; }
        public DbSet<Verbale> Verbali { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anagrafica>()
                .HasKey(a => a.Idanagrafica);
            modelBuilder.Entity<TipoViolazione>()
                .HasKey(tv => tv.Idviolazione);
            modelBuilder.Entity<Verbale>()
                .HasKey(v => v.Idverbale);

            modelBuilder.Entity<Verbale>()
                .HasOne(v => v.Anagrafica)
                .WithMany()
                .HasForeignKey(v => v.Idanagrafica);

            modelBuilder.Entity<Verbale>()
                .HasOne(v => v.TipoViolazione)
                .WithMany()
                .HasForeignKey(v => v.Idviolazione);

            base.OnModelCreating(modelBuilder);
        }
    }
}
