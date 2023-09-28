using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace member.DTOs.memberDTOs
{
    public class searchOutputDTO
    {
        public int Id { get; set; }
  
        public string name { get; set; }
        public int age { get; set; }

        public decimal height { get; set; }

        public DateTime dob { get; set; }
    }
}
