using Microsoft.EntityFrameworkCore;
using PersonasRegisterApp.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PersonasRegisterApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Contacto> Contactos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Persona>()
                .HasIndex(p => p.DocumentoIdentidad)
                .IsUnique();
        }
    }
}