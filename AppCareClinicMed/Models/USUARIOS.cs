using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppCareClinicMed.Models {
    public class USUARIOS {

        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string usuario { get; set; }

        [StringLength(20)]
        public string senha { get; set; }
    }
}
