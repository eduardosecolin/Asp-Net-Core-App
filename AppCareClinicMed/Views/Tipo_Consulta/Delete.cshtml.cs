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
    public class DeleteModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public DeleteModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TIPO_CONSULTA = await _context.TIPO_CONSULTA.FindAsync(id);

            if (TIPO_CONSULTA != null)
            {
                _context.TIPO_CONSULTA.Remove(TIPO_CONSULTA);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
