using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.Historico
{
    public class DeleteModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public DeleteModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HISTORICO_PACIENTE = await _context.HISTORICO_PACIENTE.FindAsync(id);

            if (HISTORICO_PACIENTE != null)
            {
                _context.HISTORICO_PACIENTE.Remove(HISTORICO_PACIENTE);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
