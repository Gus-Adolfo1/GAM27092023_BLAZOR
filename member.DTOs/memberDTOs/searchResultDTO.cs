using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace member.DTOs.memberDTOs
{
    public class searchResultDTO
    {
        public int id { get; set; }

        [Display(Name = "Nombre")]
        public string name { get; set; }

        [Display(Name = "Apellido")]
        public string lastname { get; set; }

        [Display(Name = "Edad")]
        public int age { get; set; }

        [Display(Name = "Estatura")]
        public decimal height { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime dob { get; set; }

    }
}
