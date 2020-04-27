using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadore.Infra.Migrations
{
    public partial class campoPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Usuario",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Usuario",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 12);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Usuario",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Usuario",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Usuario",
                type: "TEXT",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
