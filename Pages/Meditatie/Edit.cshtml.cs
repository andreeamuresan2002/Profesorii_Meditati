using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Profesorii_Meditati.Data;
using Profesorii_Meditati.Models;

namespace Profesorii_Meditati.Pages.Meditatie
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Profesorii_Meditati.Data.Profesorii_MeditatiContext _context;

        public EditModel(Profesorii_Meditati.Data.Profesorii_MeditatiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Profesorii_Meditati.Models.Meditatie Meditatie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meditatie =  await _context.Meditatie.FirstOrDefaultAsync(m => m.Id == id);
            if (meditatie == null)
            {
                return NotFound();
            }
            Meditatie = meditatie;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Meditatie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeditatieExists(Meditatie.Id))
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

        private bool MeditatieExists(int id)
        {
            return _context.Meditatie.Any(e => e.Id == id);
        }
    }
}
