using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.Agendamento
{
    public class DeleteModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public DeleteModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AGENDAMENTO = await _context.AGENDAMENTO.FindAsync(id);

            if (AGENDAMENTO != null)
            {
                _context.AGENDAMENTO.Remove(AGENDAMENTO);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
