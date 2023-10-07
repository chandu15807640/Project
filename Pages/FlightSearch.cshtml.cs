using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LindnerAirlines.Data;
using LindnerAirlines.Models;

namespace LindnerAirlines.Pages
{
    public class FlightSearchModel : PageModel
    {
        private readonly LindnerAirlines.Data.ApplicationDbContext _context;

        public FlightSearchModel(LindnerAirlines.Data.ApplicationDbContext context)
        {
            _context = context;
        }


        public IList<Flight> Flight { get; set; }



        public bool SearchCompleted { get; set; }



        public string Source { get; set; }



        public string Destination { get; set; }



        public async Task OnGetAsync(string source = null, string destination = null)

        {

            Source = source;

            Destination = destination;

            if (!string.IsNullOrWhiteSpace(source) && !string.IsNullOrWhiteSpace(destination))

            {

                SearchCompleted = true;



                Flight = await _context.Flight

                    .Where(x => x.Source.StartsWith(source) && x.Destination.StartsWith(destination))

                    .ToListAsync();

            }

            else

            {

                SearchCompleted = false;

                Flight = new List<Flight>();

            }

        }

    }

}
