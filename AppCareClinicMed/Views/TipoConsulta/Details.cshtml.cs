using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.TipoConsulta
{
    public class DetailsModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public DetailsModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
        {
            _context = context;
        }

        public TIPO_CONSULTA TIPO_CONSULTA { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TIPO_CONSULTA = await _context.TIPO_CONSULTA.FirstOrDefaultAsync(m => m.Id == id);

            if (TIPO_CONSULTA == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
