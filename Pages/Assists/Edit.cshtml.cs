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

namespace LindnerAirlines.Pages.Assists
{
    public class EditModel : PageModel
    {
        private readonly LindnerAirlines.Data.ApplicationDbContext _context;

        public EditModel(LindnerAirlines.Data.ApplicationDbContext context)
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

            var assist =  await _context.Assist.FirstOrDefaultAsync(m => m.Id == id);
            if (assist == null)
            {
                return NotFound();
            }
            Assist = assist;
           ViewData["UserId"] = new SelectList(_context.User, "Id", "Email");
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

            _context.Attach(Assist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssistExists(Assist.Id))
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

        private bool AssistExists(int id)
        {
          return (_context.Assist?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
