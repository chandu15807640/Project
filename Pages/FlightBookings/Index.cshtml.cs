using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LindnerAirlines.Data;
using LindnerAirlines.Models;

namespace LindnerAirlines.Pages.FlightBookings
{
    public class IndexModel : PageModel
    {
        private readonly LindnerAirlines.Data.ApplicationDbContext _context;

        public IndexModel(LindnerAirlines.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FlightBooking> FlightBooking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FlightBooking != null)
            {
                FlightBooking = await _context.FlightBooking
                .Include(f => f.Booking)
                .Include(f => f.Flight).ToListAsync();
            }
        }
    }
}
