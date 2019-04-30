using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppCareClinicMed.Models {
    public class PACIENTE {

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        public DateTime Data_nascimento { get; set; }

        [StringLength(20)]
        public string Sexo { get; set; }

        [StringLength(20)]
        public string Estado_civil { get; set; }

        [StringLength(50)]
        public string Endereco { get; set; }

        public int Numero { get; set; }

        [StringLength(50)]
        public string Cidade { get; set; }

        public ESTADOS Estado { get; set; }

        public int ESTADOSId { get; set; }

        public PAIS Pais { get; set; }

        public int PAISId { get; set; }

        [StringLength(15)]
        public string Cpf { get; set; }

        [StringLength(20)]
        public string Rg { get; set; }

        public CONVENIO Convenio { get; set; }

        public int CONVENIOId { get; set; }
    }
}
