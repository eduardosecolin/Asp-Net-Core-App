﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppCareClinicMed.Models {
    public class PAIS {

        public PAIS() {

        }

        public PAIS(string pais) {
            Pais = pais;
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Pais { get; set; }
    }
}
