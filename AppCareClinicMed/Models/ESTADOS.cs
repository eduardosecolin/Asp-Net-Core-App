using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppCareClinicMed.Models {
    public class ESTADOS {

        [Key]
        public int Id { get; set; }

        [StringLength(2)]
        public string Estado { get; set; }
    }
}
