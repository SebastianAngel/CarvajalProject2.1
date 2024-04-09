using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Carvajar_2._1.Models.Data
{
    public partial class REQUERIMIENTOSContext : DbContext
    {
        public REQUERIMIENTOSContext()
        {
        }

        public REQUERIMIENTOSContext(DbContextOptions<REQUERIMIENTOSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Caracteristica> Caracteristicas { get; set; } = null!;
        public virtual DbSet<Complejidad> Complejidads { get; set; } = null!;
      
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Ingeniero> Ingenieros { get; set; } = null!;
        public virtual DbSet<Periodicidad> Periodicidads { get; set; } = null!;
        public virtual DbSet<Solicitante> Solicitantes { get; set; } = null!;
        public virtual DbSet<Solicitud> Solicitudes { get; set; } = null!;
        public virtual DbSet<TipoSolicitud> TipoSolicituds { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caracteristica>(entity =>
            {
                entity.HasKey(e => e.IdCaracteristica)
                    .HasName("PK__CARACTER__8761175C79F52866");

                entity.ToTable("CARACTERISTICA");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Complejidad>(entity =>
            {
                entity.HasKey(e => e.IdComplejidad)
                    .HasName("PK__COMPLEJI__512EFCE381984611");

                entity.ToTable("COMPLEJIDAD");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

           

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__ESTADO__FBB0EDC18C86B92A");

                entity.ToTable("ESTADO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ingeniero>(entity =>
            {
                entity.HasKey(e => e.IdIngeniero)
                    .HasName("PK__INGENIER__C5B62C821A4385C5");

                entity.ToTable("INGENIEROS");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.Rol)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sede)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Periodicidad>(entity =>
            {
                entity.HasKey(e => e.IdPeriodicidad)
                    .HasName("PK__PERIODIC__DA476CCD2EC87A34");

                entity.ToTable("PERIODICIDAD");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Solicitante>(entity =>
            {
                entity.HasKey(e => e.IdSolicitante)
                    .HasName("PK__SOLICITA__B6EB1200719B9BD8");

                entity.ToTable("SOLICITANTE");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.HasKey(e => e.IdSolicitud)
                    .HasName("PK__SOLICITU__36899CEF96E362BF");

                entity.ToTable("SOLICITUDES");

                entity.Property(e => e.AislamientoFisico)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Aislamiento_fisico");

                entity.Property(e => e.AsuntoEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Asunto_email");

                entity.Property(e => e.CertificadoEmail).HasColumnName("Certificado_email");

                entity.Property(e => e.ClaveEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Clave_email");

                entity.Property(e => e.Cliente)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ContenidoPublicacion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Contenido_publicacion");

                entity.Property(e => e.Correo)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CuerpoEmail)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Cuerpo_email");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DominioCorpEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DominioCorp_email");

                entity.Property(e => e.DominioEmail)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("Dominio_email");

                entity.Property(e => e.EncriptadoEmail).HasColumnName("Encriptado_email");

                entity.Property(e => e.FechaAprobacion).HasColumnName("Fecha_Aprobacion");

                entity.Property(e => e.FechaFinal).HasColumnName("Fecha_Final");

                entity.Property(e => e.FechaInicio).HasColumnName("Fecha_Inicio");

                entity.Property(e => e.FechaPruebas).HasColumnName("Fecha_Pruebas");

                entity.Property(e => e.FechaSolicitud).HasColumnName("Fecha_solicitud");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mensaje)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePdf)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.Pdf).HasColumnName("PDF");

                entity.Property(e => e.Producto)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ReqAmbiente)
                    .HasMaxLength(900)
                    .IsUnicode(false)
                    .HasColumnName("Req_Ambiente");

                entity.Property(e => e.ReqAmbienteFile)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Req_AmbienteFile");

                entity.Property(e => e.ReqFunc)
                    .HasMaxLength(900)
                    .IsUnicode(false)
                    .HasColumnName("Req_Func");

                entity.Property(e => e.ReqFuncFile)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Req_FuncFile");

                entity.Property(e => e.ReqNoFunc)
                    .HasMaxLength(900)
                    .IsUnicode(false)
                    .HasColumnName("Req_NoFunc");

                entity.Property(e => e.ReqNoFuncFile)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Req_NoFuncFile");

                entity.Property(e => e.Sms).HasColumnName("SMS");

                entity.Property(e => e.Solicitante)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.TamanoFisico)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Tamano_fisico");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoEntrega)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_Entrega");

                entity.Property(e => e.TipoFisico).HasColumnName("Tipo_fisico");

                entity.Property(e => e.TipoPapelFisico)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TipoPapel_fisico");

                entity.HasOne(d => d.IdCaracteristicaNavigation)
                    .WithMany(p => p.Solicitudes)
                    .HasForeignKey(d => d.IdCaracteristica)
                    .HasConstraintName("FK__SOLICITUD__IdCar__32E0915F");

                entity.HasOne(d => d.IdComplejidadNavigation)
                    .WithMany(p => p.Solicitudes)
                    .HasForeignKey(d => d.IdComplejidad)
                    .HasConstraintName("FK__SOLICITUD__IdCom__34C8D9D1");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Solicitudes)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK__SOLICITUD__IdEst__33D4B598");

                entity.HasOne(d => d.IdIngenieroNavigation)
                    .WithMany(p => p.Solicitudes)
                    .HasForeignKey(d => d.IdIngeniero)
                    .HasConstraintName("FK__SOLICITUD__IdIng__36B12243");

                entity.HasOne(d => d.IdPeriodicidadNavigation)
                    .WithMany(p => p.Solicitudes)
                    .HasForeignKey(d => d.IdPeriodicidad)
                    .HasConstraintName("FK__SOLICITUD__IdPer__35BCFE0A");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Solicitudes)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__SOLICITUD__IdTip__31EC6D26");
            });

            modelBuilder.Entity<TipoSolicitud>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__TIPO_SOL__9E3A29A5E1796604");

                entity.ToTable("TIPO_SOLICITUD");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
