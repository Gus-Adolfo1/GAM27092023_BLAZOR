using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace member.DTOs.memberDTOs
{
    public class searchQueryDTO
    {
        [Display(Name = "Nombre")]
        public string? nameLike { get; set; }
        [Display(Name = "LastName")]
        public string? lastnameLike { get; set; }
        [Display(Name = "pagina")]
        public int Skip { get; set; }
        [Display(Name = "CantReg X Pagina")]
        public int Take { get; set; }

        public byte SendRowCount { get; set; }
    }
}
