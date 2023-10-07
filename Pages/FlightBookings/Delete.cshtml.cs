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
    public class DeleteModel : PageModel
    {
        private readonly LindnerAirlines.Data.ApplicationDbContext _context;

        public DeleteModel(LindnerAirlines.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public FlightBooking FlightBooking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FlightBooking == null)
            {
                return NotFound();
            }

            var flightbooking = await _context.FlightBooking.FirstOrDefaultAsync(m => m.Id == id);

            if (flightbooking == null)
            {
                return NotFound();
            }
            else 
            {
                FlightBooking = flightbooking;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.FlightBooking == null)
            {
                return NotFound();
            }
            var flightbooking = await _context.FlightBooking.FindAsync(id);

            if (flightbooking != null)
            {
                FlightBooking = flightbooking;
                _context.FlightBooking.Remove(FlightBooking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
