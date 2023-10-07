using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LindnerAirlines.Data;
using LindnerAirlines.Models;

namespace LindnerAirlines.Pages.Assists
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
        ViewData["UserId"] = new SelectList(_context.User, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Assist Assist { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Assist == null || Assist == null)
            {
                return Page();
            }

            _context.Assist.Add(Assist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
