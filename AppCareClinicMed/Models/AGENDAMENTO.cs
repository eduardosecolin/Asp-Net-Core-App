using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppCareClinicMed.Models {
    public class AGENDAMENTO {

        [Key]
        public int Id { get; set; }

        [StringLength(5)]
        public string retorno { get; set; }

        public DateTime Data_agendamento { get; set; }

        public PACIENTE Paciente { get; set; }

        public int PACIENTEId { get; set; }

        public MEDICO Medico { get; set; }

        public int MEDICOId { get; set; }

        public TIPO_CONSULTA Tipo_consulta { get; set; }

        public int TIPO_CONSULTAId { get; set; }

        public CONVENIO Convenio { get; set; }

        public int CONVENIOId { get; set; }

        public FORMA_PAGAMENTO Forma_pagamento { get; set; }

        public int FORMA_PAGAMENTOId { get; set; }
    }
}
