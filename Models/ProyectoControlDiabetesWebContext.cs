using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto1.Models;

public partial class ProyectoControlDiabetesWebContext : DbContext
{
    public ProyectoControlDiabetesWebContext()
    {
    }

    public ProyectoControlDiabetesWebContext(DbContextOptions<ProyectoControlDiabetesWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Consulta> Consultas { get; set; }

    public virtual DbSet<Doctore> Doctores { get; set; }

    public virtual DbSet<Medicamento> Medicamentos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Receta> Recetas { get; set; }

    public virtual DbSet<RegistrosGlucosa> RegistrosGlucosas { get; set; }

    public virtual DbSet<RegistrosMedico> RegistrosMedicos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.Idcita).HasName("PK__Citas__36D350ABF0AA4C20");

            entity.Property(e => e.Idcita).HasColumnName("IDCita");
            entity.Property(e => e.EstadoCita)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaHoraCita).HasColumnType("datetime");
            entity.Property(e => e.Iddoctor).HasColumnName("IDDoctor");
            entity.Property(e => e.Idpaciente).HasColumnName("IDPaciente");
            entity.Property(e => e.NotasCita).IsUnicode(false);

            entity.HasOne(d => d.IddoctorNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.Iddoctor)
                .HasConstraintName("FK__Citas__IDDoctor__35BCFE0A");

            entity.HasOne(d => d.IdpacienteNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.Idpaciente)
                .HasConstraintName("FK__Citas__IDPacient__34C8D9D1");
        });

        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.HasKey(e => e.Idconsulta).HasName("PK__Consulta__420D6C8C4087178C");

            entity.Property(e => e.Idconsulta).HasColumnName("IDConsulta");
            entity.Property(e => e.DescripcionConsulta).IsUnicode(false);
            entity.Property(e => e.FechaConsulta).HasColumnType("datetime");
            entity.Property(e => e.Glucosa).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Iddoctor).HasColumnName("IDDoctor");
            entity.Property(e => e.Idpaciente).HasColumnName("IDPaciente");
            entity.Property(e => e.Peso).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.PresionArterial)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IddoctorNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.Iddoctor)
                .HasConstraintName("FK__Consultas__IDDoc__2B3F6F97");

            entity.HasOne(d => d.IdpacienteNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.Idpaciente)
                .HasConstraintName("FK__Consultas__IDPac__2A4B4B5E");
        });

        modelBuilder.Entity<Doctore>(entity =>
        {
            entity.HasKey(e => e.Iddoctor).HasName("PK__Doctores__A4F7F9ECBE61EA30");

            entity.Property(e => e.Iddoctor).HasColumnName("IDDoctor");
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Dpi).HasMaxLength(25);
            entity.Property(e => e.Especialidad)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreDoctor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono).HasMaxLength(15);
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.Idmedicamento).HasName("PK__Medicame__9228C2E408701BBB");

            entity.Property(e => e.Idmedicamento).HasColumnName("IDMedicamento");
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Idpaciente).HasName("PK__Paciente__94DF170F55F3F659");

            entity.Property(e => e.Idpaciente).HasColumnName("IDPaciente");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Dpi).HasMaxLength(20);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TipoDiabetes).HasMaxLength(100);
        });

        modelBuilder.Entity<Receta>(entity =>
        {
            entity.HasKey(e => e.Idreceta).HasName("PK__Recetas__91B4C6BCF99D15DF");

            entity.Property(e => e.Idreceta).HasColumnName("IDReceta");
            entity.Property(e => e.Frecuencia)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Idconsulta).HasColumnName("IDConsulta");
            entity.Property(e => e.Idmedicamento).HasColumnName("IDMedicamento");

            entity.HasOne(d => d.IdconsultaNavigation).WithMany(p => p.Receta)
                .HasForeignKey(d => d.Idconsulta)
                .HasConstraintName("FK__Recetas__IDConsu__300424B4");

            entity.HasOne(d => d.IdmedicamentoNavigation).WithMany(p => p.Receta)
                .HasForeignKey(d => d.Idmedicamento)
                .HasConstraintName("FK__Recetas__IDMedic__30F848ED");
        });

        modelBuilder.Entity<RegistrosGlucosa>(entity =>
        {
            entity.HasKey(e => e.IdregistroGlucosa).HasName("PK__Registro__69422C130699AC72");

            entity.ToTable("RegistrosGlucosa");

            entity.Property(e => e.IdregistroGlucosa).HasColumnName("IDRegistroGlucosa");
            entity.Property(e => e.Comentarios).IsUnicode(false);
            entity.Property(e => e.FechaHoraRegistro).HasColumnType("datetime");
            entity.Property(e => e.Idpaciente).HasColumnName("IDPaciente");
            entity.Property(e => e.NivelGlucosa).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.IdpacienteNavigation).WithMany(p => p.RegistrosGlucosas)
                .HasForeignKey(d => d.Idpaciente)
                .HasConstraintName("FK__Registros__IDPac__38996AB5");
        });

        modelBuilder.Entity<RegistrosMedico>(entity =>
        {
            entity.HasKey(e => e.IdregistroMedico).HasName("PK__Registro__F27D53664D095112");

            entity.Property(e => e.IdregistroMedico).HasColumnName("IDRegistroMedico");
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaHoraRegistro).HasColumnType("datetime");
            entity.Property(e => e.Idpaciente).HasColumnName("IDPaciente");
            entity.Property(e => e.TipoRegistro)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdpacienteNavigation).WithMany(p => p.RegistrosMedicos)
                .HasForeignKey(d => d.Idpaciente)
                .HasConstraintName("FK__Registros__IDPac__3B75D760");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__Usuarios__523111696A80D12C");

            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Iddoctor).HasColumnName("IDDoctor");
            entity.Property(e => e.Idpaciente).HasColumnName("IDPaciente");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono).HasMaxLength(15);
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
