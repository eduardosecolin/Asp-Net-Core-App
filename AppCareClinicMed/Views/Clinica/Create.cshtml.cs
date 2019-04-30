using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.Clinica
{
    public class CreateModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public CreateModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ESTADOSId"] = new SelectList(_context.Set<ESTADOS>(), "Id", "Id");
        ViewData["PAISId"] = new SelectList(_context.Set<ESTADOS>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public CLINICA CLINICA { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CLINICA.Add(CLINICA);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}