using LindnerAirlines.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LindnerAirlines.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly LindnerAirlines.Data.ApplicationDbContext _context;

        public IndexModel(LindnerAirlines.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public int TotalFlights { get; set; }
        public int TotalBookings { get; set; }
        public int TotalUsers { get; set; }

        public int TotalAssists { get; set; }

        public int TotalPayments { get; set; }

        public async Task OnGetAsync(FlightBooking flightBooking)
        {
            TotalFlights = await _context.Flight.CountAsync();
            TotalBookings = await _context.Booking.CountAsync();
            TotalUsers = await _context.Users.CountAsync();
            TotalAssists = await _context.Assist.CountAsync();
            TotalPayments = await _context.Payment.CountAsync();
        }
    }
}
