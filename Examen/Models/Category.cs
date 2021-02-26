using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    [Table("Categories", Schema = "Cat")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Proporcione un nombre.")]
        [MaxLengthAttribute(50, ErrorMessage = "50 es el máximo de caracteres")]
        [MinLengthAttribute(1, ErrorMessage = "Nombre no puede ser vacío")]
        public string NameCategory { get; set; }
    }
}