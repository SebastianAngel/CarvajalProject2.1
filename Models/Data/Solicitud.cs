using System;
using System.Collections.Generic;

namespace Carvajar_2._1.Models.Data
{
    public partial class Solicitud
    {
        public int IdSolicitud { get; set; }
        public string? Solicitante { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Cliente { get; set; }
        public int? IdTipo { get; set; }
        public string? Producto { get; set; }
        public int? IdCaracteristica { get; set; }
        public int? IdEstado { get; set; }
        public int? IdComplejidad { get; set; }
        public string? Descripcion { get; set; }
        public int? Estado { get; set; }
        public int? IdPeriodicidad { get; set; }
        public bool? Email { get; set; }
        public string? AsuntoEmail { get; set; }
        public string? DominioCorpEmail { get; set; }
        public string? CuerpoEmail { get; set; }
        public string? NombrePdf { get; set; }
        public bool? EncriptadoEmail { get; set; }
        public string? ClaveEmail { get; set; }
        public bool? CertificadoEmail { get; set; }
        public string? DominioEmail { get; set; }
        public bool? Sms { get; set; }
        public string? Mensaje { get; set; }
        public bool? Fisico { get; set; }
        public bool? Color { get; set; }
        public string? AislamientoFisico { get; set; }
        public string? TamanoFisico { get; set; }
        public string? TipoPapelFisico { get; set; }
        public bool? TipoFisico { get; set; }
        public bool? Microperforado { get; set; }
        public bool? Pdf { get; set; }
        public string? TipoEntrega { get; set; }
        public bool? Publicacion { get; set; }
        public string? ContenidoPublicacion { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaPruebas { get; set; }
        public DateTime? FechaAprobacion { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string? ReqFunc { get; set; }
        public string? ReqNoFunc { get; set; }
        public string? ReqAmbiente { get; set; }
        public int? IdIngeniero { get; set; }
        public string? Identificacion { get; set; }
        public string? ReqFuncFile { get; set; }
        public string? ReqNoFuncFile { get; set; }
        public string? ReqAmbienteFile { get; set; }

        public virtual Caracteristica? IdCaracteristicaNavigation { get; set; }
        public virtual Complejidad? IdComplejidadNavigation { get; set; }
        public virtual Estado? IdEstadoNavigation { get; set; }
        public virtual Ingeniero? IdIngenieroNavigation { get; set; }
        public virtual Periodicidad? IdPeriodicidadNavigation { get; set; }
        public virtual TipoSolicitud? IdTipoNavigation { get; set; }
    }
}
