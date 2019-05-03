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
        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Informe a data de nascimento")]
        public DateTime Data_nascimento { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Informe o sexo")]
        public string Sexo { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Informe o estado civil")]
        public string Estado_civil { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Informe o endereço")]
        public string Endereco { get; set; }

        public int Numero { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Informe a cidade")]
        public string Cidade { get; set; }

        public ESTADOS Estado { get; set; }

        public int ESTADOSId { get; set; }

        public PAIS Pais { get; set; }

        public int PAISId { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "Informe o CPF")]
        [DisplayFormat(DataFormatString = "{0:000\\.000\\.000-00}", ApplyFormatInEditMode = true)]
        public string Cpf { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Informe o RG")]
        [DisplayFormat(DataFormatString = "{0:00\\.000\\.000-00}", ApplyFormatInEditMode = true)]
        public string Rg { get; set; }

        public CONVENIO Convenio { get; set; }

        public int CONVENIOId { get; set; }
    }
}
