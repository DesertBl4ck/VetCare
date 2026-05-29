using Microsoft.EntityFrameworkCore;
using VetCare.Models;

namespace VetCare.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Mascota> Mascotas { get; set; }
    public DbSet<Cita> Citas { get; set; }
    public DbSet<DetalleServicio> DetalleServicios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mascota>()
            .HasMany(m => m.Citas)
            .WithOne(c => c.Mascota)
            .HasForeignKey(c => c.MascotaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Cita>()
            .HasMany(c => c.Detalles)
            .WithOne(d => d.Cita)
            .HasForeignKey(d => d.CitaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Mascota>().HasIndex(m => m.NombreDueno);
        modelBuilder.Entity<Cita>().HasIndex(c => c.Fecha);
    }
}