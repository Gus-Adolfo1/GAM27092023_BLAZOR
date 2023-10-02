using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace member.DTOs.memberDTOs
{
    public class EditMemberDTO
    {
      
            public EditMemberDTO(searchResultDTO searchOut)
            {
                id = searchOut.id;
                name = searchOut.name;
                lastname = searchOut.lastname;
                age = searchOut.age;
                height = searchOut.height;
                dob = searchOut.dob;
            }

            public EditMemberDTO()
            {
                name = string.Empty;
                lastname = string.Empty;
            }

            [Required(ErrorMessage = "El campo es obligatorio.")]
            public int id { get; set; }

            [Display(Name = "Nombre")]
            [Required(ErrorMessage = "El campo nombre es obligatorio.")]
            [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 carácteres.")]
            public string name { get; set; }

            [Display(Name = "Apellido")]
            [Required(ErrorMessage = "El campo apellido es obligatorio.")]
            [MaxLength(50, ErrorMessage = "El campo Apellido no puede tener más de 50 carácteres.")]
            public string lastname { get; set; }

            [Display(Name = "Edad")]
            [Required(ErrorMessage = "El campo Edad es obligatorio.")]
            [Range(0, 150, ErrorMessage = "La edad debe estar entre 0 y 150.")]
            public int age { get; set; }

            [Display(Name = "Estatura")]
            [Required(ErrorMessage = "El campo estatura es obligatorio.")]
            [Range(0.50, 3.00, ErrorMessage = "La estatura no debe ser mayor a 3m")]
            public decimal height { get; set; }

            [Display(Name = "Fecha de Nacimiento")]
            [Required(ErrorMessage = "El campo fecha es obligatorio.")]
            public DateTime dob { get; set; }
        }
    }

