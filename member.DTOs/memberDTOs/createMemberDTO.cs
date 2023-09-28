using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace member.DTOs.memberDTOs
{
    internal class createMemberDTO
    {
        public string name { get; set; }
        public int age { get; set; }

        public decimal height { get; set; }

        public DateTime dob { get; set; }
    }
}
