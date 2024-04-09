using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carvajar_2._1.Models.Data
{
    public partial class Periodicidad
    {
        public Periodicidad()
        {
            Solicitudes = new HashSet<Solicitud>();
        }

        public int IdPeriodicidad { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
        public string? Descripcion { get; set; }

        public virtual ICollection<Solicitud> Solicitudes { get; set; }
    }
}
