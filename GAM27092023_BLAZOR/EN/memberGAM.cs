﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GAM27092023_BLAZOR.EN
{
    public class memberGAM
    {    
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        public int age { get; set; }

        public decimal height { get; set; }

        public DateTime dob { get; set; }

    }
}
