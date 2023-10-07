using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LindnerAirlines.Data;
using LindnerAirlines.Models;

namespace LindnerAirlines.Pages.FlightBookings
{
    public class CreateModel : PageModel
    {
        private readonly LindnerAirlines.Data.ApplicationDbContext _context;

        public CreateModel(LindnerAirlines.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BookingId"] = new SelectList(_context.Booking, "Id", "Id");
        ViewData["FlightId"] = new SelectList(_context.Flight, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public FlightBooking FlightBooking { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.FlightBooking == null || FlightBooking == null)
            {
                return Page();
            }

            _context.FlightBooking.Add(FlightBooking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
