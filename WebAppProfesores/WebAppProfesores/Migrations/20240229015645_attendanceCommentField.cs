using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppProfesores.Migrations
{
    /// <inheritdoc />
    public partial class attendanceCommentField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "comment",
                table: "Attendaces",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "comment",
                table: "Attendaces");
        }
    }
}
