using Microsoft.EntityFrameworkCore.Migrations;

namespace UploadFile.Data.Migrations
{
    public partial class intialstep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RandomNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    A = table.Column<double>(type: "float", nullable: false),
                    B = table.Column<double>(type: "float", nullable: false),
                    C = table.Column<double>(type: "float", nullable: false),
                    D = table.Column<double>(type: "float", nullable: false),
                    E = table.Column<double>(type: "float", nullable: false),
                    F = table.Column<double>(type: "float", nullable: false),
                    G = table.Column<double>(type: "float", nullable: false),
                    H = table.Column<double>(type: "float", nullable: false),
                    I = table.Column<double>(type: "float", nullable: false),
                    J = table.Column<double>(type: "float", nullable: false),
                    K = table.Column<double>(type: "float", nullable: false),
                    L = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandomNumbers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RandomNumbers");
        }
    }
}
