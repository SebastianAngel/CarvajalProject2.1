using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carvajar_2._1.Models.Data
{
    public partial class Solicitante
    {
        public int IdSolicitante { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Identificacion es obligatorio")]
        [StringLength(10, ErrorMessage = "La Identificacion es de minimo 7 caracteres y maximo 10", MinimumLength = 7)]
        public string? Identificacion { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        [EmailAddress]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El campo Empresa es obligatorio")]
        public string? Empresa { get; set; }

        [Required(ErrorMessage = "El campo Empresa es obligatorio")]
        public string? Cargo { get; set; }

    }
}
