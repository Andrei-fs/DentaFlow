using Microsoft.EntityFrameworkCore.Migrations;

namespace DentaFlow.Migrations
{
    public partial class DoctorsPacientsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Cabinet = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    Availability = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "Pacients",
                columns: table => new
                {
                    PacientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacients", x => x.PacientId);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentHour = table.Column<string>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    PacientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Pacients_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacients",
                        principalColumn: "PacientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorsPacients",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false),
                    PacientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsPacients", x => new { x.DoctorId, x.PacientId });
                    table.ForeignKey(
                        name: "FK_DoctorsPacients_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorsPacients_Pacients_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacients",
                        principalColumn: "PacientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PacientId",
                table: "Appointments",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorsPacients_PacientId",
                table: "DoctorsPacients",
                column: "PacientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "DoctorsPacients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Pacients");
        }
    }
}
