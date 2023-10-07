using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LindnerAirlines.Data;
using LindnerAirlines.Models;

namespace LindnerAirlines.Pages.FlightBookings
{
    public class EditModel : PageModel
    {
        private readonly LindnerAirlines.Data.ApplicationDbContext _context;

        public EditModel(LindnerAirlines.Data.ApplicationDbContext context)
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

            var flightbooking =  await _context.FlightBooking.FirstOrDefaultAsync(m => m.Id == id);
            if (flightbooking == null)
            {
                return NotFound();
            }
            FlightBooking = flightbooking;
           ViewData["BookingId"] = new SelectList(_context.Booking, "Id", "Id");
           ViewData["FlightId"] = new SelectList(_context.Flight, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FlightBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightBookingExists(FlightBooking.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FlightBookingExists(int id)
        {
          return (_context.FlightBooking?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
