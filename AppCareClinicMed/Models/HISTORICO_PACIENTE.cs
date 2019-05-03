using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppCareClinicMed.Models {
    public class HISTORICO_PACIENTE {

        [Key]
        public int Id { get; set; }

        [StringLength(2000)]
        [Required(ErrorMessage = "Informe a descrição do histórico")]
        public string Historico { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Informe a data")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_historico { get; set; }

        public PACIENTE Paciente { get; set; }

        public int PACIENTEId { get; set; }

        public MEDICO Medico { get; set; }

        public int MEDICOId { get; set; }
    }
}
