using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.Historico
{
    public class EditModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public EditModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HISTORICO_PACIENTE HISTORICO_PACIENTE { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HISTORICO_PACIENTE = await _context.HISTORICO_PACIENTE
                .Include(h => h.Medico)
                .Include(h => h.Paciente).FirstOrDefaultAsync(m => m.Id == id);

            if (HISTORICO_PACIENTE == null)
            {
                return NotFound();
            }
           ViewData["MEDICOId"] = new SelectList(_context.Set<MEDICO>(), "Id", "Id");
           ViewData["PACIENTEId"] = new SelectList(_context.Set<PACIENTE>(), "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(HISTORICO_PACIENTE).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HISTORICO_PACIENTEExists(HISTORICO_PACIENTE.Id))
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

        private bool HISTORICO_PACIENTEExists(int id)
        {
            return _context.HISTORICO_PACIENTE.Any(e => e.Id == id);
        }
    }
}
