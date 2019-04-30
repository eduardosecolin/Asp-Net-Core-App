using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.Historico
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
        ViewData["MEDICOId"] = new SelectList(_context.Set<MEDICO>(), "Id", "Id");
        ViewData["PACIENTEId"] = new SelectList(_context.Set<PACIENTE>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public HISTORICO_PACIENTE HISTORICO_PACIENTE { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.HISTORICO_PACIENTE.Add(HISTORICO_PACIENTE);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}