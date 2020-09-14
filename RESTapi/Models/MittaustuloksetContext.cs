using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RESTapi.Models
{
    public class MittaustuloksetContext : DbContext
    {
        public MittaustuloksetContext(DbContextOptions<MittaustuloksetContext> options)
            : base(options)
        {
        }

        public DbSet<Henkilot> Henkilot { get; set; }
        public DbSet<Mittaukset> Mittaukset { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Henkilot>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Hetu).IsRequired();

                entity.Property(e => e.Nimi).IsRequired();
            });

            modelBuilder.Entity<Mittaukset>(entity =>
            {
                entity.HasKey(e => e.MittausId);

                entity.Property(e => e.MittausId).ValueGeneratedNever();

                entity.Property(e => e.Hetu).IsRequired();

                entity.HasOne(d => d.Henkilot)
                    .WithMany(p => p.Mittaukset)
                    .HasForeignKey(d => d.HenkilotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
