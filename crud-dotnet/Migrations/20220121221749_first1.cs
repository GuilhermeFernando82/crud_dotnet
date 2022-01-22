using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crud_dotnet.Migrations
{
    public partial class first1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "tb_usuario");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_usuario",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_usuario",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "dataNascimento",
                table: "tb_usuario",
                newName: "data");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_usuario",
                table: "tb_usuario",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_usuario",
                table: "tb_usuario");

            migrationBuilder.RenameTable(
                name: "tb_usuario",
                newName: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Usuarios",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Usuarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "data",
                table: "Usuarios",
                newName: "dataNascimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");
        }
    }
}
