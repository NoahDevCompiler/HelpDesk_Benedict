using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDesk_Benedict.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTicketComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Visibility",
                table: "TicketComments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "TicketComments");
        }
    }
}
