using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.Paciente
{
    public class DetailsModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public DetailsModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
        {
            _context = context;
        }

        public PACIENTE PACIENTE { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PACIENTE = await _context.PACIENTE
                .Include(p => p.Convenio)
                .Include(p => p.Estado)
                .Include(p => p.Pais).FirstOrDefaultAsync(m => m.Id == id);

            if (PACIENTE == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
