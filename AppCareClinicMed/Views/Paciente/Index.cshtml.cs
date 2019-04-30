using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.Paciente
{
    public class IndexModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public IndexModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
        {
            _context = context;
        }

        public IList<PACIENTE> PACIENTE { get;set; }

        public async Task OnGetAsync()
        {
            PACIENTE = await _context.PACIENTE
                .Include(p => p.Convenio)
                .Include(p => p.Estado)
                .Include(p => p.Pais).ToListAsync();
        }
    }
}
