using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetCore8AuthDemo.Migrations
{
    /// <inheritdoc />
    public partial class addMatriculeField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Matricule",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Matricule",
                table: "AspNetUsers");
        }
    }
}
