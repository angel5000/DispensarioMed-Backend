using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using static DispenarioMedBCK.Repositorio.RepositorioCitasMedicas;

namespace DispenarioMedBCK.Models;

public partial class DispensarioContext : DbContext
{
    public DispensarioContext()
    {
    }

    public DispensarioContext(DbContextOptions<DispensarioContext> options)
        : base(options)
    {
    }
 
    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<AuditoriaPaciente> AuditoriaPacientes { get; set; }

    public virtual DbSet<CitasCanceladasHistorial> CitasCanceladasHistorials { get; set; }

    public virtual DbSet<CitasMedica> CitasMedicas { get; set; }

    public virtual DbSet<CostoServicio> CostoServicios { get; set; }

    public virtual DbSet<EjemploTabla> EjemploTablas { get; set; }

    public virtual DbSet<Especialidad> Especialidads { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<EstadoHoraCita> EstadoHoraCitas { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<HistorialMedico> HistorialMedicos { get; set; }

    public virtual DbSet<HorariosCita> HorariosCitas { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<MotivosCitasMedica> MotivosCitasMedicas { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<PagosRealizado> PagosRealizados { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<TelefonosPaciente> TelefonosPacientes { get; set; }

    public virtual DbSet<Ubicacion> Ubicacions { get; set; }

    public virtual DbSet<UsuariosMedico> UsuariosMedicos { get; set; }

    public virtual DbSet<UsuariosPaciente> UsuariosPacientes { get; set; }

    public virtual DbSet<UsuariosinactivosHistorial> UsuariosinactivosHistorials { get; set; }

/*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-BUQ5QOC;Database=DispensarioMed;User Id=sa;Password=Angpro500; TrustServerCertificate=true;");
    */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.IdAreas).HasName("PK__Areas__D121A76AC8CD052C");

            entity.Property(e => e.IdAreas).HasColumnName("ID_Areas");
            entity.Property(e => e.Habitacion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdDoctor).HasColumnName("ID_Doctor");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Areas)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MEDICoFK2");

            entity.HasOne(d => d.UbicacionareaNavigation).WithMany(p => p.Areas)
                .HasForeignKey(d => d.Ubicacionarea)
                .HasConstraintName("areaubifk");
        });

        modelBuilder.Entity<AuditoriaPaciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Auditori__62CD58D730486225");

            entity.Property(e => e.IdPaciente).HasColumnName("ID_PACIENTE");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Canton)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Fecha_nacimiento");
            entity.Property(e => e.Genero)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Provincia)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CitasCanceladasHistorial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CitasCan__3214EC27130C6547");

            entity.ToTable("CitasCanceladasHistorial");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.CitaMedicaNavigation).WithMany(p => p.CitasCanceladasHistorials)
                .HasForeignKey(d => d.CitaMedica)
                .HasConstraintName("CtCn");

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.CitasCanceladasHistorials)
                .HasForeignKey(d => d.Estado)
                .HasConstraintName("Estdct");

            entity.HasOne(d => d.EstadoCitaNavigation).WithMany(p => p.CitasCanceladasHistorials)
                .HasForeignKey(d => d.EstadoCita)
                .HasConstraintName("Estct");
        });

        modelBuilder.Entity<CitasMedica>(entity =>
        {
            entity.HasKey(e => e.Idcita).HasName("PK__Citas_Me__36D350AB96C80FB3");

            entity.ToTable("Citas_Medicas");

            entity.Property(e => e.Idcita).HasColumnName("IDCita");
            entity.Property(e => e.IdhorarioCitas).HasColumnName("IDHorarioCitas");
            entity.Property(e => e.Idmedico).HasColumnName("IDMedico");
            entity.Property(e => e.Idpaciente).HasColumnName("IDPaciente");

            entity.HasOne(d => d.IdhorarioCitasNavigation).WithMany(p => p.CitasMedicas)
                .HasForeignKey(d => d.IdhorarioCitas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("horariocitafk");

            entity.HasOne(d => d.IdmedicoNavigation).WithMany(p => p.CitasMedicas)
                .HasForeignKey(d => d.Idmedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicfk");

            entity.HasOne(d => d.IdpacienteNavigation).WithMany(p => p.CitasMedicas)
                .HasForeignKey(d => d.Idpaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pcientffk");

            entity.HasOne(d => d.MotivoNavigation).WithMany(p => p.CitasMedicas)
                .HasForeignKey(d => d.Motivo)
                .HasConstraintName("motivfk");
        });

        modelBuilder.Entity<CostoServicio>(entity =>
        {
            entity.HasKey(e => e.IdcostServi).HasName("PK__CostoSer__7BF738B10E8CA20E");

            entity.Property(e => e.IdcostServi).HasColumnName("IDCostServi");
            entity.Property(e => e.Idmcm).HasColumnName("IDMCM");

            entity.HasOne(d => d.IdmcmNavigation).WithMany(p => p.CostoServicios)
                .HasForeignKey(d => d.Idmcm)
                .HasConstraintName("Motivosfk");
        });

        modelBuilder.Entity<EjemploTabla>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EjemploT__3214EC27766A3892");

            entity.ToTable("EjemploTabla");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Datos).HasMaxLength(255);
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.Idespecialidad).HasName("PK__Especial__A265362FE232932A");

            entity.ToTable("Especialidad");

            entity.Property(e => e.Idespecialidad).HasColumnName("IDEspecialidad");
            entity.Property(e => e.Especialidad1)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Especialidad");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estados__3214EC2790EC5EA7");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estados)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoHoraCita>(entity =>
        {
            entity.HasKey(e => e.IdEstadhocita).HasName("PK__EstadoHo__9F83B2AF6433C155");

            entity.Property(e => e.IdEstadhocita).HasColumnName("ID_Estadhocita");
            entity.Property(e => e.Disponibilidad)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__Factura__E9D586A89F80C469");

            entity.ToTable("Factura");

            entity.Property(e => e.IdFactura).HasColumnName("ID_Factura");
            entity.Property(e => e.Costo).HasColumnName("costo");
            entity.Property(e => e.IdMedico).HasColumnName("ID_Medico");
            entity.Property(e => e.IdPaciente).HasColumnName("ID_Paciente");

            entity.HasOne(d => d.FechaVisitaNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.FechaVisita)
                .HasConstraintName("Citafk2");

            entity.HasOne(d => d.IdMedicoNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdMedico)
                .HasConstraintName("mediccofk2");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("pcientefk2");

            entity.HasOne(d => d.MotivoNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.Motivo)
                .HasConstraintName("Motivofk");
        });

        modelBuilder.Entity<HistorialMedico>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("PK__Historia__ECA89454CFFD2FAB");

            entity.ToTable("Historial_Medico");

            entity.Property(e => e.IdHistorial).HasColumnName("ID_Historial");
            entity.Property(e => e.Diagnostico)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IdMedico).HasColumnName("ID_Medico");
            entity.Property(e => e.IdPaciente).HasColumnName("ID_Paciente");
            entity.Property(e => e.Receta)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Sintomas)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tratamiento)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.FechaVisitaNavigation).WithMany(p => p.HistorialMedicos)
                .HasForeignKey(d => d.FechaVisita)
                .HasConstraintName("Citafk");

            entity.HasOne(d => d.IdMedicoNavigation).WithMany(p => p.HistorialMedicos)
                .HasForeignKey(d => d.IdMedico)
                .HasConstraintName("mediccofk");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.HistorialMedicos)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("pcientefk");
        });

        modelBuilder.Entity<HorariosCita>(entity =>
        {
            entity.HasKey(e => e.IdHorario).HasName("PK__Horarios__CDBBBA340C455B37");

            entity.ToTable(tb => tb.HasTrigger("trigger_Horacitas"));

            entity.Property(e => e.IdHorario).HasColumnName("ID_HORARIO");
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.IdDoctor).HasColumnName("ID_Doctor");

            entity.HasOne(d => d.AreasNavigation).WithMany(p => p.HorariosCita)
                .HasForeignKey(d => d.Areas)
                .HasConstraintName("Areahfk");

            entity.HasOne(d => d.Disponibe).WithMany(p => p.HorariosCita)
                .HasForeignKey(d => d.Disponibeid)
                .HasConstraintName("Disponifk");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.HorariosCita)
                .HasForeignKey(d => d.IdDoctor)
                .HasConstraintName("MEDICoFK");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.IdMedico).HasName("PK__Medico__4595B547CA102C9C");

            entity.ToTable("Medico");

            entity.HasIndex(e => e.Especialidad, "idx_EspeMedi");

            entity.Property(e => e.IdMedico).HasColumnName("ID_medico");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CodigoMedico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DireccionDomicilio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Especialidad)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumCelular)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.UbicacionDispNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.UbicacionDisp)
                .HasConstraintName("Ubicafk");
        });

        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasKey(e => e.IdMetPago).HasName("PK__MetodoPa__70C3951FCBE418CD");

            entity.ToTable("MetodoPago");

            entity.Property(e => e.IdMetPago).HasColumnName("ID_MetPago");
            entity.Property(e => e.Metodo)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MotivosCitasMedica>(entity =>
        {
            entity.HasKey(e => e.Idmotivo).HasName("PK__MotivosC__2133556BE3EDDC6F");

            entity.Property(e => e.Idmotivo).HasColumnName("IDMotivo");
            entity.Property(e => e.EspecialiMed).HasColumnName("especialiMed");
            entity.Property(e => e.Servicio)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.EspecialiMedNavigation).WithMany(p => p.MotivosCitasMedicas)
                .HasForeignKey(d => d.EspecialiMed)
                .HasConstraintName("espicalfk");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__paciente__62CD58D7B919577C");

            entity.ToTable("pacientes", tb =>
                {
                    tb.HasTrigger("trigger_audipaciente");
                    tb.HasTrigger("trigger_audiupdpaciente");
                    tb.HasTrigger("trigger_pacientes");
                });

            entity.Property(e => e.IdPaciente).HasColumnName("ID_PACIENTE");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Canton)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("canton");
            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Fecha_nacimiento");
            entity.Property(e => e.Genero)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumCelular)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Provincia)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PagosRealizado>(entity =>
        {
            entity.HasKey(e => e.IdMetPago).HasName("PK__PagosRea__70C3951F3FCE1D41");

            entity.Property(e => e.IdMetPago).HasColumnName("ID_MetPago");
            entity.Property(e => e.IdMetodoPago).HasColumnName("idMetodoPago");
            entity.Property(e => e.IdMotivo).HasColumnName("idMotivo");

            entity.HasOne(d => d.IdMetodoPagoNavigation).WithMany(p => p.PagosRealizados)
                .HasForeignKey(d => d.IdMetodoPago)
                .HasConstraintName("Metodopg");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.PagosRealizados)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("pcintefk2");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Idrol).HasName("PK__Rol__A681ACB68AC0969A");

            entity.ToTable("Rol");

            entity.Property(e => e.Idrol).HasColumnName("IDRol");
            entity.Property(e => e.Rol1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Rol");
        });

        modelBuilder.Entity<TelefonosPaciente>(entity =>
        {
            entity.HasKey(e => e.IdTelefono).HasName("PK__Telefono__80E081E4257A4AF3");

            entity.Property(e => e.IdTelefono).HasColumnName("ID_Telefono");
            entity.Property(e => e.IdPaciente).HasColumnName("ID_Paciente");
            entity.Property(e => e.NumeroTelefono)
                .HasMaxLength(14)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.TelefonosPacientes)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("numpcfk");
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.Idubicacion).HasName("PK__Ubicacio__B4CA90FC9200DF7D");

            entity.ToTable("Ubicacion");

            entity.Property(e => e.Idubicacion).HasColumnName("IDUbicacion");
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Sector)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsuariosMedico>(entity =>
        {
            entity.HasKey(e => e.IdmedUsuario).HasName("PK__Usuarios__C7A46E980AEACB32");

            entity.ToTable("UsuariosMedico");

            entity.HasIndex(e => e.Usuario, "UQ__Usuarios__E3237CF7FC7367FA").IsUnique();

            entity.Property(e => e.IdmedUsuario).HasColumnName("IDMedUsuario");
            entity.Property(e => e.Activa)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HashedContrasena).HasMaxLength(64);
            entity.Property(e => e.IdDatosUsuario).HasColumnName("ID_DatosUsuario");
            entity.Property(e => e.Salt).HasMaxLength(32);
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDatosUsuarioNavigation).WithMany(p => p.UsuariosMedicos)
                .HasForeignKey(d => d.IdDatosUsuario)
                .HasConstraintName("Usuariomedfk");

            entity.HasOne(d => d.RolNavigation).WithMany(p => p.UsuariosMedicos)
                .HasForeignKey(d => d.Rol)
                .HasConstraintName("Rolfkk2");
        });

        modelBuilder.Entity<UsuariosPaciente>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__Usuarios__52311169E4593A9B");

            entity.ToTable("UsuariosPaciente");

            entity.HasIndex(e => e.Usuario, "UQ__Usuarios__E3237CF708381395").IsUnique();

            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.Activa)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HashedContrasena).HasMaxLength(64);
            entity.Property(e => e.IdDatosUsuario).HasColumnName("ID_DatosUsuario");
            entity.Property(e => e.Salt).HasMaxLength(32);
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDatosUsuarioNavigation).WithMany(p => p.UsuariosPacientes)
                .HasForeignKey(d => d.IdDatosUsuario)
                .HasConstraintName("UsuarioPCTfk");

            entity.HasOne(d => d.RolNavigation).WithMany(p => p.UsuariosPacientes)
                .HasForeignKey(d => d.Rol)
                .HasConstraintName("Rolfk");
        });

        modelBuilder.Entity<UsuariosinactivosHistorial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC27B8948748");

            entity.ToTable("UsuariosinactivosHistorial");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.UsuariosinactivosHistorials)
                .HasForeignKey(d => d.Estado)
                .HasConstraintName("Estd");

            entity.HasOne(d => d.MedicosNavigation).WithMany(p => p.UsuariosinactivosHistorials)
                .HasForeignKey(d => d.Medicos)
                .HasConstraintName("medinac");

            entity.HasOne(d => d.PacientesNavigation).WithMany(p => p.UsuariosinactivosHistorials)
                .HasForeignKey(d => d.Pacientes)
                .HasConstraintName("pcieninac");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
