using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LindnerAirlines.Data;
using LindnerAirlines.Models;

namespace LindnerAirlines.Pages.Flights
{
    public class DetailsModel : PageModel
    {
        private readonly LindnerAirlines.Data.ApplicationDbContext _context;

        public DetailsModel(LindnerAirlines.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Flight Flight { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Flight == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight.FirstOrDefaultAsync(m => m.Id == id);
            if (flight == null)
            {
                return NotFound();
            }
            else 
            {
                Flight = flight;
            }
            return Page();
        }
    }
}
