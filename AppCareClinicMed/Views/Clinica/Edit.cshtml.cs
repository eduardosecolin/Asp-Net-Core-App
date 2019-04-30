using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.Clinica
{
    public class EditModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public EditModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["ESTADOSId"] = new SelectList(_context.Set<ESTADOS>(), "Id", "Id");
           ViewData["PAISId"] = new SelectList(_context.Set<ESTADOS>(), "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CLINICA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CLINICAExists(CLINICA.Id))
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

        private bool CLINICAExists(int id)
        {
            return _context.CLINICA.Any(e => e.Id == id);
        }
    }
}
