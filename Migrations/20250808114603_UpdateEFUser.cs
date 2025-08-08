using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDesk_Benedict.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEFUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdminConfirmed",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminConfirmed",
                table: "AspNetUsers");
        }
    }
}
