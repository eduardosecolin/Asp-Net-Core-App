using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppCareClinicMed.Models;

namespace AppCareClinicMed.Models
{
    public class AppCareClinicMedContext : DbContext
    {

        public AppCareClinicMedContext() {

        }

        public AppCareClinicMedContext (DbContextOptions<AppCareClinicMedContext> options)
            : base(options)
        {
        }
        public DbSet<AppCareClinicMed.Models.AGENDAMENTO> AGENDAMENTO { get; set; }
        public DbSet<AppCareClinicMed.Models.CLINICA> CLINICA { get; set; }
        public DbSet<AppCareClinicMed.Models.CONVENIO> CONVENIO { get; set; }
        public DbSet<AppCareClinicMed.Models.ESPECIALIDADE> ESPECIALIDADE { get; set; }
        public DbSet<AppCareClinicMed.Models.FORMA_PAGAMENTO> FORMA_PAGAMENTO { get; set; }
        public DbSet<AppCareClinicMed.Models.HISTORICO_PACIENTE> HISTORICO_PACIENTE { get; set; }
        public DbSet<AppCareClinicMed.Models.MEDICO> MEDICO { get; set; }
        public DbSet<AppCareClinicMed.Models.PACIENTE> PACIENTE { get; set; }
        public DbSet<AppCareClinicMed.Models.TIPO_CONSULTA> TIPO_CONSULTA { get; set; }
        public DbSet<AppCareClinicMed.Models.USUARIOS> USUARIOS { get; set; }
        public DbSet<AppCareClinicMed.Models.ESTADOS> ESTADOS { get; set; }
        public DbSet<AppCareClinicMed.Models.PAIS> PAIS { get; set; }
    }
}
