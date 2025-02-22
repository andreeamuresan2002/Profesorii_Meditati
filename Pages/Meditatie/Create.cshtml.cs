﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Profesorii_Meditati.Data;
using Profesorii_Meditati.Models;

namespace Profesorii_Meditati.Pages.Meditatie
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Profesorii_Meditati.Data.Profesorii_MeditatiContext _context;

        public CreateModel(Profesorii_Meditati.Data.Profesorii_MeditatiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Profesorii_Meditati.Models.Meditatie Meditatie { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Meditatie.Add(Meditatie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
