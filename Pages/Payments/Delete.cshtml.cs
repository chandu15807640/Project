using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LindnerAirlines.Data;
using LindnerAirlines.Models;

namespace LindnerAirlines.Pages.Payments
{
    public class DeleteModel : PageModel
    {
        private readonly LindnerAirlines.Data.ApplicationDbContext _context;

        public DeleteModel(LindnerAirlines.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Payment Payment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Payment == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment.FirstOrDefaultAsync(m => m.Id == id);

            if (payment == null)
            {
                return NotFound();
            }
            else 
            {
                Payment = payment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Payment == null)
            {
                return NotFound();
            }
            var payment = await _context.Payment.FindAsync(id);

            if (payment != null)
            {
                Payment = payment;
                _context.Payment.Remove(Payment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
