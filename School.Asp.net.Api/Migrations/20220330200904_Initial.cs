using Microsoft.EntityFrameworkCore.Migrations;

namespace School.Asp.net.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Classid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassCourse = table.Column<int>(type: "int", nullable: false),
                    ClassType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Classid);
                });

            migrationBuilder.CreateTable(
                name: "Pupil",
                columns: table => new
                {
                    Pupilid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupil", x => x.Pupilid);
                    table.ForeignKey(
                        name: "FK_Pupil_Class_Classid",
                        column: x => x.Classid,
                        principalTable: "Class",
                        principalColumn: "Classid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pupil_Classid",
                table: "Pupil",
                column: "Classid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pupil");

            migrationBuilder.DropTable(
                name: "Class");
        }
    }
}
