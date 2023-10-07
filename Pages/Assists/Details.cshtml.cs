using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LindnerAirlines.Data;
using LindnerAirlines.Models;

namespace LindnerAirlines.Pages.Assists
{
    public class DetailsModel : PageModel
    {
        private readonly LindnerAirlines.Data.ApplicationDbContext _context;

        public DetailsModel(LindnerAirlines.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Assist Assist { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Assist == null)
            {
                return NotFound();
            }

            var assist = await _context.Assist.FirstOrDefaultAsync(m => m.Id == id);
            if (assist == null)
            {
                return NotFound();
            }
            else 
            {
                Assist = assist;
            }
            return Page();
        }
    }
}
