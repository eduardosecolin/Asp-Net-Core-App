using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppCareClinicMed.Models {
    public class ESPECIALIDADE {

        public ESPECIALIDADE() {

        }

        public ESPECIALIDADE(string descricao) {
            Descricao = descricao;
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Informe a descrição")]
        public string Descricao { get; set; }
    }
}
