using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.Agendamento
{
    public class EditModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public EditModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AGENDAMENTO AGENDAMENTO { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AGENDAMENTO = await _context.AGENDAMENTO
                .Include(a => a.Convenio)
                .Include(a => a.Medico)
                .Include(a => a.Paciente)
                .Include(a => a.Tipo_consulta).FirstOrDefaultAsync(m => m.Id == id);

            if (AGENDAMENTO == null)
            {
                return NotFound();
            }
           ViewData["CONVENIOId"] = new SelectList(_context.Set<CONVENIO>(), "Id", "Id");
           ViewData["MEDICOId"] = new SelectList(_context.Set<MEDICO>(), "Id", "Id");
           ViewData["PACIENTEId"] = new SelectList(_context.Set<PACIENTE>(), "Id", "Id");
           ViewData["TIPO_CONSULTAId"] = new SelectList(_context.Set<TIPO_CONSULTA>(), "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AGENDAMENTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AGENDAMENTOExists(AGENDAMENTO.Id))
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

        private bool AGENDAMENTOExists(int id)
        {
            return _context.AGENDAMENTO.Any(e => e.Id == id);
        }
    }
}
