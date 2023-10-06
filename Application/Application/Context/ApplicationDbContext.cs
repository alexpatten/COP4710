using Application.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Doctors> Doctors { get; set; }
    public DbSet<Patients> Patients { get; set; }
    public DbSet<Doctors_User> DoctorsUsers { get; set; }
    public DbSet<Patients_User> PatientsUsers { get; set; }
}
