using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.Medico
{
    public class DeleteModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public DeleteModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MEDICO MEDICO { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MEDICO = await _context.MEDICO
                .Include(m => m.Especialidade).FirstOrDefaultAsync(m => m.Id == id);

            if (MEDICO == null)
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

            MEDICO = await _context.MEDICO.FindAsync(id);

            if (MEDICO != null)
            {
                _context.MEDICO.Remove(MEDICO);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
