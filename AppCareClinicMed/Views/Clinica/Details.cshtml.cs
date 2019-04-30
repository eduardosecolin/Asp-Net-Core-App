using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.Clinica
{
    public class DetailsModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public DetailsModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
        {
            _context = context;
        }

        public CLINICA CLINICA { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CLINICA = await _context.CLINICA
                .Include(c => c.Estado)
                .Include(c => c.Pais).FirstOrDefaultAsync(m => m.Id == id);

            if (CLINICA == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
