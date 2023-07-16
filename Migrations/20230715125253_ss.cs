using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group_Project.Migrations
{
    /// <inheritdoc />
    public partial class ss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Teachers",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Teachers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Teachers",
                newName: "Name");
        }
    }
}
