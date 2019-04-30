using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Views.Especialidade
{
    public class IndexModel : PageModel
    {
        private readonly AppCareClinicMed.Models.AppCareClinicMedContext _context;

        public IndexModel(AppCareClinicMed.Models.AppCareClinicMedContext context)
        {
            _context = context;
        }

        public IList<ESPECIALIDADE> ESPECIALIDADE { get;set; }

        public async Task OnGetAsync()
        {
            ESPECIALIDADE = await _context.ESPECIALIDADE.ToListAsync();
        }
    }
}
