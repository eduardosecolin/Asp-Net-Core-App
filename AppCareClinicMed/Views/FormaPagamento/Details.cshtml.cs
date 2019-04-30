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
    public class DetailsModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public DetailsModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
        {
            _context = context;
        }

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
    }
}
