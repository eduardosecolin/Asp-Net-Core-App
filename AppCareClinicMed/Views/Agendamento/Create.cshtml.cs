using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.Agendamento
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
        ViewData["CONVENIOId"] = new SelectList(_context.Set<CONVENIO>(), "Id", "Id");
        ViewData["MEDICOId"] = new SelectList(_context.Set<MEDICO>(), "Id", "Id");
        ViewData["PACIENTEId"] = new SelectList(_context.Set<PACIENTE>(), "Id", "Id");
        ViewData["TIPO_CONSULTAId"] = new SelectList(_context.Set<TIPO_CONSULTA>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public AGENDAMENTO AGENDAMENTO { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AGENDAMENTO.Add(AGENDAMENTO);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}