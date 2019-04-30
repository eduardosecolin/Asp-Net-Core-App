using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.Historico
{
    public class IndexModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public IndexModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
        {
            _context = context;
        }

        public IList<HISTORICO_PACIENTE> HISTORICO_PACIENTE { get;set; }

        public async Task OnGetAsync()
        {
            HISTORICO_PACIENTE = await _context.HISTORICO_PACIENTE
                .Include(h => h.Medico)
                .Include(h => h.Paciente).ToListAsync();
        }
    }
}
