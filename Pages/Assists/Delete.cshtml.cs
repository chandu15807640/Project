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
    public class DeleteModel : PageModel
    {
        private readonly LindnerAirlines.Data.ApplicationDbContext _context;

        public DeleteModel(LindnerAirlines.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Assist == null)
            {
                return NotFound();
            }
            var assist = await _context.Assist.FindAsync(id);

            if (assist != null)
            {
                Assist = assist;
                _context.Assist.Remove(Assist);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
