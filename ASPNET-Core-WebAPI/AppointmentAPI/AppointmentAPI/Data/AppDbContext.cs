using AppointmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Service>()
            .Property(x => x.Price)
            .HasPrecision(10, 2);
    }
}