using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.FormaPagamento
{
    public class DeleteModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public DeleteModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FORMA_PAGAMENTO FORMA_PAGAMENTO { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FORMA_PAGAMENTO = await _context.FORMA_PAGAMENTO.FirstOrDefaultAsync(m => m.Id == id);

            if (FORMA_PAGAMENTO == null)
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

            FORMA_PAGAMENTO = await _context.FORMA_PAGAMENTO.FindAsync(id);

            if (FORMA_PAGAMENTO != null)
            {
                _context.FORMA_PAGAMENTO.Remove(FORMA_PAGAMENTO);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
