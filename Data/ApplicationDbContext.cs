using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LindnerAirlines.Models;

namespace LindnerAirlines.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<LindnerAirlines.Models.User> User { get; set; } = default!;
    public DbSet<LindnerAirlines.Models.Flight> Flight { get; set; } = default!;
    public DbSet<LindnerAirlines.Models.Booking> Booking { get; set; } = default!;
    public DbSet<LindnerAirlines.Models.Assist> Assist { get; set; } = default!;
    public DbSet<LindnerAirlines.Models.Payment> Payment { get; set; } = default!;
    public DbSet<LindnerAirlines.Models.FlightBooking> FlightBooking { get; set; } = default!;
}

