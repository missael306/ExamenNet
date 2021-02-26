using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    [Table("Projects")]
    public class Project
    {
        #region Atributtes 
        [Key]
        public int ProjectID { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Proporcione un nombre.")]
        [MaxLengthAttribute(100, ErrorMessage = "100 es el máximo de caracteres")]
        [MinLengthAttribute(1, ErrorMessage = "Nombre no puede ser vacío")]
        public string NameProject { get; set; }

        public Category Category { get; set; }
        #endregion
    }
}