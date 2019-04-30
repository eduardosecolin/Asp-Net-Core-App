﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppCareClinicMed.Models {
    public class CLINICA {

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Razao_social { get; set; }

        [StringLength(50)]
        public string Nome_fantasia { get; set; }

        [StringLength(20)]
        public string Cnpj { get; set; }

        [StringLength(50)]
        public string Endereco { get; set; }

        public int Numero { get; set; }

        [StringLength(50)]
        public string Cidade { get; set; }

        public ESTADOS Estado { get; set; }

        public int ESTADOSId { get; set; }

        public PAIS Pais { get; set; }

        public int PAISId { get; set; }
    }
}
