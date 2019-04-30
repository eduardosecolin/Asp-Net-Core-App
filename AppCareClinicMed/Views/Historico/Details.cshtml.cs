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
    public class DetailsModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public DetailsModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
        {
            _context = context;
        }

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
    }
}
