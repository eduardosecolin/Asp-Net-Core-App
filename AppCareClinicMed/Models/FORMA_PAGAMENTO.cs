﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppCareClinicMed.Models {
    public class FORMA_PAGAMENTO {

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Descricao { get; set; }

    }
}
