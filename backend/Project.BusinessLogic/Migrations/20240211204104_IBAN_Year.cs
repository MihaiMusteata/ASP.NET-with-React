using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.BusinessLogic.Migrations
{
    /// <inheritdoc />
    public partial class IBAN_Year : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "IBans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "IBans");
        }
    }
}
