using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.Paciente
{
    public class EditModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public EditModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["CONVENIOId"] = new SelectList(_context.CONVENIO, "Id", "Id");
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

            _context.Attach(PACIENTE).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PACIENTEExists(PACIENTE.Id))
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

        private bool PACIENTEExists(int id)
        {
            return _context.PACIENTE.Any(e => e.Id == id);
        }
    }
}
