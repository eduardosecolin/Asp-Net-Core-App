using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppCareClinicMed.Models {
    public class MEDICO {

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Informe o crm")]
        public string Crm { get; set; }

        public ESPECIALIDADE Especialidade { get; set; }

        public int ESPECIALIDADEId { get; set; }
    }
}
