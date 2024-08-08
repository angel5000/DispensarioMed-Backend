using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DispenarioMedBCK.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditoriaPacientes",
                columns: table => new
                {
                    ID_PACIENTE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Fecha_nacimiento = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Provincia = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Canton = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Genero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Auditori__62CD58D730486225", x => x.ID_PACIENTE);
                });

            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    IDEspecialidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Especialidad = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Especial__A265362FE232932A", x => x.IDEspecialidad);
                });

            migrationBuilder.CreateTable(
                name: "EstadoHoraCitas",
                columns: table => new
                {
                    ID_Estadhocita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disponibilidad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EstadoHo__9F83B2AF6433C155", x => x.ID_Estadhocita);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estados = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Estados__3214EC2790EC5EA7", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPago",
                columns: table => new
                {
                    ID_MetPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Metodo = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MetodoPa__70C3951FCBE418CD", x => x.ID_MetPago);
                });

            migrationBuilder.CreateTable(
                name: "pacientes",
                columns: table => new
                {
                    ID_PACIENTE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Nombres = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Apellidos = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Fecha_nacimiento = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Provincia = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Direccion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NumCelular = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    canton = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Genero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CorreoElectronico = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__paciente__62CD58D7B919577C", x => x.ID_PACIENTE);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IDRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rol__A681ACB68AC0969A", x => x.IDRol);
                });

            migrationBuilder.CreateTable(
                name: "TelefonosPacientes",
                columns: table => new
                {
                    ID_Telefono = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Paciente = table.Column<int>(type: "int", nullable: true),
                    NumeroTelefono = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Telefono__80E081E4257A4AF3", x => x.ID_Telefono);
                });

            migrationBuilder.CreateTable(
                name: "Ubicacion",
                columns: table => new
                {
                    IDUbicacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sector = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Direccion = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ubicacio__B4CA90FC9200DF7D", x => x.IDUbicacion);
                });

            migrationBuilder.CreateTable(
                name: "MotivosCitasMedicas",
                columns: table => new
                {
                    IDMotivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Servicio = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    especialiMed = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MotivosC__2133556BE3EDDC6F", x => x.IDMotivo);
                    table.ForeignKey(
                        name: "espicalfk",
                        column: x => x.especialiMed,
                        principalTable: "Especialidad",
                        principalColumn: "IDEspecialidad");
                });

            migrationBuilder.CreateTable(
                name: "PagosRealizados",
                columns: table => new
                {
                    ID_MetPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: true),
                    idMotivo = table.Column<int>(type: "int", nullable: true),
                    idMetodoPago = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PagosRea__70C3951F3FCE1D41", x => x.ID_MetPago);
                    table.ForeignKey(
                        name: "Metodopg",
                        column: x => x.idMetodoPago,
                        principalTable: "MetodoPago",
                        principalColumn: "ID_MetPago");
                    table.ForeignKey(
                        name: "pcintefk2",
                        column: x => x.IdPaciente,
                        principalTable: "pacientes",
                        principalColumn: "ID_PACIENTE");
                });

            migrationBuilder.CreateTable(
                name: "UsuariosPaciente",
                columns: table => new
                {
                    IDUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_DatosUsuario = table.Column<int>(type: "int", nullable: true),
                    Usuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Rol = table.Column<int>(type: "int", nullable: true),
                    Activa = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Salt = table.Column<byte[]>(type: "varbinary(32)", maxLength: 32, nullable: false),
                    HashedContrasena = table.Column<byte[]>(type: "varbinary(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__52311169E4593A9B", x => x.IDUsuario);
                    table.ForeignKey(
                        name: "Rolfk",
                        column: x => x.Rol,
                        principalTable: "Rol",
                        principalColumn: "IDRol");
                    table.ForeignKey(
                        name: "UsuarioPCTfk",
                        column: x => x.ID_DatosUsuario,
                        principalTable: "pacientes",
                        principalColumn: "ID_PACIENTE");
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    ID_medico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoMedico = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Cedula = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Nombres = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Apellidos = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Especialidad = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    NumCelular = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    DireccionDomicilio = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    UbicacionDisp = table.Column<int>(type: "int", nullable: true),
                    Genero = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    CorreoElectronico = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Especialidadid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Medico__4595B547CA102C9C", x => x.ID_medico);
                    table.ForeignKey(
                        name: "Ubicafk",
                        column: x => x.UbicacionDisp,
                        principalTable: "Ubicacion",
                        principalColumn: "IDUbicacion");
                });

            migrationBuilder.CreateTable(
                name: "CostoServicios",
                columns: table => new
                {
                    IDCostServi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDMCM = table.Column<int>(type: "int", nullable: true),
                    Costos = table.Column<double>(type: "float", nullable: true),
                    Descuentos = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CostoSer__7BF738B10E8CA20E", x => x.IDCostServi);
                    table.ForeignKey(
                        name: "Motivosfk",
                        column: x => x.IDMCM,
                        principalTable: "MotivosCitasMedicas",
                        principalColumn: "IDMotivo");
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    ID_Areas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Doctor = table.Column<int>(type: "int", nullable: false),
                    Habitacion = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Ubicacionarea = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Areas__D121A76AC8CD052C", x => x.ID_Areas);
                    table.ForeignKey(
                        name: "MEDICoFK2",
                        column: x => x.ID_Doctor,
                        principalTable: "Medico",
                        principalColumn: "ID_medico");
                    table.ForeignKey(
                        name: "areaubifk",
                        column: x => x.Ubicacionarea,
                        principalTable: "Ubicacion",
                        principalColumn: "IDUbicacion");
                });

            migrationBuilder.CreateTable(
                name: "UsuariosinactivosHistorial",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pacientes = table.Column<int>(type: "int", nullable: true),
                    Medicos = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__3214EC27B8948748", x => x.ID);
                    table.ForeignKey(
                        name: "Estd",
                        column: x => x.Estado,
                        principalTable: "Estados",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "medinac",
                        column: x => x.Medicos,
                        principalTable: "Medico",
                        principalColumn: "ID_medico");
                    table.ForeignKey(
                        name: "pcieninac",
                        column: x => x.Pacientes,
                        principalTable: "pacientes",
                        principalColumn: "ID_PACIENTE");
                });

            migrationBuilder.CreateTable(
                name: "UsuariosMedico",
                columns: table => new
                {
                    IDMedUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_DatosUsuario = table.Column<int>(type: "int", nullable: true),
                    Usuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Rol = table.Column<int>(type: "int", nullable: true),
                    Activa = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Salt = table.Column<byte[]>(type: "varbinary(32)", maxLength: 32, nullable: false),
                    HashedContrasena = table.Column<byte[]>(type: "varbinary(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__C7A46E980AEACB32", x => x.IDMedUsuario);
                    table.ForeignKey(
                        name: "Rolfkk2",
                        column: x => x.Rol,
                        principalTable: "Rol",
                        principalColumn: "IDRol");
                    table.ForeignKey(
                        name: "Usuariomedfk",
                        column: x => x.ID_DatosUsuario,
                        principalTable: "Medico",
                        principalColumn: "ID_medico");
                });

            migrationBuilder.CreateTable(
                name: "HorariosCitas",
                columns: table => new
                {
                    ID_HORARIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Doctor = table.Column<int>(type: "int", nullable: true),
                    Areas = table.Column<int>(type: "int", nullable: true),
                    FechaHora = table.Column<DateTime>(type: "datetime", nullable: true),
                    Disponibeid = table.Column<int>(type: "int", nullable: true),
                    FechaFin = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Horarios__CDBBBA340C455B37", x => x.ID_HORARIO);
                    table.ForeignKey(
                        name: "Areahfk",
                        column: x => x.Areas,
                        principalTable: "Areas",
                        principalColumn: "ID_Areas");
                    table.ForeignKey(
                        name: "Disponifk",
                        column: x => x.Disponibeid,
                        principalTable: "EstadoHoraCitas",
                        principalColumn: "ID_Estadhocita");
                    table.ForeignKey(
                        name: "MEDICoFK",
                        column: x => x.ID_Doctor,
                        principalTable: "Medico",
                        principalColumn: "ID_medico");
                });

            migrationBuilder.CreateTable(
                name: "Citas_Medicas",
                columns: table => new
                {
                    IDCita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPaciente = table.Column<int>(type: "int", nullable: false),
                    IDMedico = table.Column<int>(type: "int", nullable: false),
                    IDHorarioCitas = table.Column<int>(type: "int", nullable: false),
                    Motivo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Citas_Me__36D350AB96C80FB3", x => x.IDCita);
                    table.ForeignKey(
                        name: "horariocitafk",
                        column: x => x.IDHorarioCitas,
                        principalTable: "HorariosCitas",
                        principalColumn: "ID_HORARIO");
                    table.ForeignKey(
                        name: "medicfk",
                        column: x => x.IDMedico,
                        principalTable: "Medico",
                        principalColumn: "ID_medico");
                    table.ForeignKey(
                        name: "motivfk",
                        column: x => x.Motivo,
                        principalTable: "MotivosCitasMedicas",
                        principalColumn: "IDMotivo");
                    table.ForeignKey(
                        name: "pcientffk",
                        column: x => x.IDPaciente,
                        principalTable: "pacientes",
                        principalColumn: "ID_PACIENTE");
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    ID_Factura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Paciente = table.Column<int>(type: "int", nullable: true),
                    ID_Medico = table.Column<int>(type: "int", nullable: true),
                    FechaVisita = table.Column<int>(type: "int", nullable: true),
                    Motivo = table.Column<int>(type: "int", nullable: true),
                    Subtotal = table.Column<double>(type: "float", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: true),
                    Iva = table.Column<double>(type: "float", nullable: true),
                    costo = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Factura__E9D586A89F80C469", x => x.ID_Factura);
                    table.ForeignKey(
                        name: "Citafk2",
                        column: x => x.FechaVisita,
                        principalTable: "HorariosCitas",
                        principalColumn: "ID_HORARIO");
                    table.ForeignKey(
                        name: "Motivofk",
                        column: x => x.Motivo,
                        principalTable: "MotivosCitasMedicas",
                        principalColumn: "IDMotivo");
                    table.ForeignKey(
                        name: "mediccofk2",
                        column: x => x.ID_Medico,
                        principalTable: "Medico",
                        principalColumn: "ID_medico");
                    table.ForeignKey(
                        name: "pcientefk2",
                        column: x => x.ID_Paciente,
                        principalTable: "pacientes",
                        principalColumn: "ID_PACIENTE");
                });

            migrationBuilder.CreateTable(
                name: "Historial_Medico",
                columns: table => new
                {
                    ID_Historial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Paciente = table.Column<int>(type: "int", nullable: true),
                    ID_Medico = table.Column<int>(type: "int", nullable: true),
                    FechaVisita = table.Column<int>(type: "int", nullable: true),
                    Sintomas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Diagnostico = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Tratamiento = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Receta = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Historia__ECA89454CFFD2FAB", x => x.ID_Historial);
                    table.ForeignKey(
                        name: "Citafk",
                        column: x => x.FechaVisita,
                        principalTable: "HorariosCitas",
                        principalColumn: "ID_HORARIO");
                    table.ForeignKey(
                        name: "mediccofk",
                        column: x => x.ID_Medico,
                        principalTable: "Medico",
                        principalColumn: "ID_medico");
                    table.ForeignKey(
                        name: "pcientefk",
                        column: x => x.ID_Paciente,
                        principalTable: "pacientes",
                        principalColumn: "ID_PACIENTE");
                });

            migrationBuilder.CreateTable(
                name: "CitasCanceladasHistorial",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitaMedica = table.Column<int>(type: "int", nullable: true),
                    EstadoCita = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CitasCan__3214EC27130C6547", x => x.ID);
                    table.ForeignKey(
                        name: "CtCn",
                        column: x => x.CitaMedica,
                        principalTable: "Citas_Medicas",
                        principalColumn: "IDCita");
                    table.ForeignKey(
                        name: "Estct",
                        column: x => x.EstadoCita,
                        principalTable: "EstadoHoraCitas",
                        principalColumn: "ID_Estadhocita");
                    table.ForeignKey(
                        name: "Estdct",
                        column: x => x.Estado,
                        principalTable: "Estados",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_ID_Doctor",
                table: "Areas",
                column: "ID_Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Ubicacionarea",
                table: "Areas",
                column: "Ubicacionarea");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Medicas_IDHorarioCitas",
                table: "Citas_Medicas",
                column: "IDHorarioCitas");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Medicas_IDMedico",
                table: "Citas_Medicas",
                column: "IDMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Medicas_IDPaciente",
                table: "Citas_Medicas",
                column: "IDPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Medicas_Motivo",
                table: "Citas_Medicas",
                column: "Motivo");

            migrationBuilder.CreateIndex(
                name: "IX_CitasCanceladasHistorial_CitaMedica",
                table: "CitasCanceladasHistorial",
                column: "CitaMedica");

            migrationBuilder.CreateIndex(
                name: "IX_CitasCanceladasHistorial_Estado",
                table: "CitasCanceladasHistorial",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_CitasCanceladasHistorial_EstadoCita",
                table: "CitasCanceladasHistorial",
                column: "EstadoCita");

            migrationBuilder.CreateIndex(
                name: "IX_CostoServicios_IDMCM",
                table: "CostoServicios",
                column: "IDMCM");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_FechaVisita",
                table: "Factura",
                column: "FechaVisita");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ID_Medico",
                table: "Factura",
                column: "ID_Medico");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ID_Paciente",
                table: "Factura",
                column: "ID_Paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_Motivo",
                table: "Factura",
                column: "Motivo");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_Medico_FechaVisita",
                table: "Historial_Medico",
                column: "FechaVisita");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_Medico_ID_Medico",
                table: "Historial_Medico",
                column: "ID_Medico");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_Medico_ID_Paciente",
                table: "Historial_Medico",
                column: "ID_Paciente");

            migrationBuilder.CreateIndex(
                name: "IX_HorariosCitas_Areas",
                table: "HorariosCitas",
                column: "Areas");

            migrationBuilder.CreateIndex(
                name: "IX_HorariosCitas_Disponibeid",
                table: "HorariosCitas",
                column: "Disponibeid");

            migrationBuilder.CreateIndex(
                name: "IX_HorariosCitas_ID_Doctor",
                table: "HorariosCitas",
                column: "ID_Doctor");

            migrationBuilder.CreateIndex(
                name: "idx_EspeMedi",
                table: "Medico",
                column: "Especialidad");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_UbicacionDisp",
                table: "Medico",
                column: "UbicacionDisp");

            migrationBuilder.CreateIndex(
                name: "IX_MotivosCitasMedicas_especialiMed",
                table: "MotivosCitasMedicas",
                column: "especialiMed");

            migrationBuilder.CreateIndex(
                name: "IX_PagosRealizados_idMetodoPago",
                table: "PagosRealizados",
                column: "idMetodoPago");

            migrationBuilder.CreateIndex(
                name: "IX_PagosRealizados_IdPaciente",
                table: "PagosRealizados",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosinactivosHistorial_Estado",
                table: "UsuariosinactivosHistorial",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosinactivosHistorial_Medicos",
                table: "UsuariosinactivosHistorial",
                column: "Medicos");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosinactivosHistorial_Pacientes",
                table: "UsuariosinactivosHistorial",
                column: "Pacientes");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosMedico_ID_DatosUsuario",
                table: "UsuariosMedico",
                column: "ID_DatosUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosMedico_Rol",
                table: "UsuariosMedico",
                column: "Rol");

            migrationBuilder.CreateIndex(
                name: "UQ__Usuarios__E3237CF7FC7367FA",
                table: "UsuariosMedico",
                column: "Usuario",
                unique: true,
                filter: "[Usuario] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPaciente_ID_DatosUsuario",
                table: "UsuariosPaciente",
                column: "ID_DatosUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPaciente_Rol",
                table: "UsuariosPaciente",
                column: "Rol");

            migrationBuilder.CreateIndex(
                name: "UQ__Usuarios__E3237CF708381395",
                table: "UsuariosPaciente",
                column: "Usuario",
                unique: true,
                filter: "[Usuario] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditoriaPacientes");

            migrationBuilder.DropTable(
                name: "CitasCanceladasHistorial");

            migrationBuilder.DropTable(
                name: "CostoServicios");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Historial_Medico");

            migrationBuilder.DropTable(
                name: "PagosRealizados");

            migrationBuilder.DropTable(
                name: "TelefonosPacientes");

            migrationBuilder.DropTable(
                name: "UsuariosinactivosHistorial");

            migrationBuilder.DropTable(
                name: "UsuariosMedico");

            migrationBuilder.DropTable(
                name: "UsuariosPaciente");

            migrationBuilder.DropTable(
                name: "Citas_Medicas");

            migrationBuilder.DropTable(
                name: "MetodoPago");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "HorariosCitas");

            migrationBuilder.DropTable(
                name: "MotivosCitasMedicas");

            migrationBuilder.DropTable(
                name: "pacientes");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "EstadoHoraCitas");

            migrationBuilder.DropTable(
                name: "Especialidad");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Ubicacion");
        }
    }
}
