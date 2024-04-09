using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carvajar_2._1.Models.Data
{
    public partial class Complejidad
    {
        public Complejidad()
        {
            Solicitudes = new HashSet<Solicitud>();
        }

        public int IdComplejidad { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
        public string? Descripcion { get; set; }

        public virtual ICollection<Solicitud> Solicitudes { get; set; }
    }
}
