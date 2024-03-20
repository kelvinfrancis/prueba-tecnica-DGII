using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace pruebaPuestoDGII.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComprobantesFiscales",
                columns: table => new
                {
                    NCF = table.Column<string>(type: "TEXT", nullable: false),
                    RncCedula = table.Column<long>(type: "INTEGER", nullable: false),
                    Monto = table.Column<double>(type: "REAL", nullable: false),
                    Itbis18 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobantesFiscales", x => x.NCF);
                });

            migrationBuilder.CreateTable(
                name: "Contribuyente",
                columns: table => new
                {
                    RncCedula = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Estatus = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuyente", x => x.RncCedula);
                });

            migrationBuilder.InsertData(
                table: "ComprobantesFiscales",
                columns: new[] { "NCF", "Itbis18", "Monto", "RncCedula" },
                values: new object[,]
                {
                    { "E310000000001", 36.0, 200.0, 98754321012L },
                    { "E310000000002", 180.0, 1000.0, 98754321012L },
                    { "E320000000001", 46.0, 300.0, 99754321012L },
                    { "E320000000002", 250.0, 2000.0, 99754321012L },
                    { "E330000000001", 80.0, 100.0, 99954321012L },
                    { "E330000000002", 120.0, 500.0, 99954321012L },
                    { "E340000000001", 90.0, 350.0, 99999321012L },
                    { "E340000000002", 110.0, 800.0, 99999321012L }
                });

            migrationBuilder.InsertData(
                table: "Contribuyente",
                columns: new[] { "RncCedula", "Estatus", "Nombre", "Tipo" },
                values: new object[,]
                {
                    { 98754321012L, "inactivo", "JUAN PEREZ", "PERSONA FISICA" },
                    { 99754321012L, "inactivo", "PEDRO DURAN", "PERSONA FISICA" },
                    { 99954321012L, "activo", "JOSE SANTANA", "PERSONA FISICA" },
                    { 99999321012L, "inactivo", "GEORGE JIMENEZ", "PERSONA FISICA" },
                    { 99999921012L, "activo", "SOCRATES TAVAREZ", "PERSONA FISICA" },
                    { 99999999012L, "activo", "ALBERTO POLANCO", "PERSONA FISICA" },
                    { 99999999912L, "inactivo", "JULIAN RODRIGUEZ", "PERSONA FISICA" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprobantesFiscales");

            migrationBuilder.DropTable(
                name: "Contribuyente");
        }
    }
}
