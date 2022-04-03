using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class ClasiProductos
    {
        [Key]
        [Required]
        [Display(Name = "Clasificacion del Producto")]
        public int ClasiProducID { get; set; }

        [Required]
        [StringLength(50)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}