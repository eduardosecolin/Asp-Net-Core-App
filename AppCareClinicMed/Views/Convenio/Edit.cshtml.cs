using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.Convenio
{
    public class EditModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public EditModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CONVENIO CONVENIO { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CONVENIO = await _context.CONVENIO.FirstOrDefaultAsync(m => m.Id == id);

            if (CONVENIO == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CONVENIO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CONVENIOExists(CONVENIO.Id))
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

        private bool CONVENIOExists(int id)
        {
            return _context.CONVENIO.Any(e => e.Id == id);
        }
    }
}
