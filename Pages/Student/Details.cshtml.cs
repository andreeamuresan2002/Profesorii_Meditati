using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Profesorii_Meditati.Data;
using Profesorii_Meditati.Models;

namespace Profesorii_Meditati.Pages.Student
{
    public class DetailsModel : PageModel
    {
        private readonly Profesorii_Meditati.Data.Profesorii_MeditatiContext _context;

        public DetailsModel(Profesorii_Meditati.Data.Profesorii_MeditatiContext context)
        {
            _context = context;
        }

        public Profesorii_Meditati.Models.Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }
            return Page();
        }
    }
}
