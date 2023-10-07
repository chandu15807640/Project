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
    public class IndexModel : PageModel
    {
        private readonly LindnerAirlines.Data.ApplicationDbContext _context;

        public IndexModel(LindnerAirlines.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Flight> Flight { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Flight != null)
            {
                Flight = await _context.Flight.ToListAsync();
            }
        }
    }
}
