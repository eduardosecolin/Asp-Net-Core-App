using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.Agendamento
{
    public class IndexModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public IndexModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
        {
            _context = context;
        }

        public IList<AGENDAMENTO> AGENDAMENTO { get;set; }

        public async Task OnGetAsync()
        {
            AGENDAMENTO = await _context.AGENDAMENTO
                .Include(a => a.Convenio)
                .Include(a => a.Medico)
                .Include(a => a.Paciente)
                .Include(a => a.Tipo_consulta).ToListAsync();
        }
    }
}
