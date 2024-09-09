using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskOneDraft.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionOfWork",
                table: "Claims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HoursWorked",
                table: "Claims",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RatePerHour",
                table: "Claims",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalAmount",
                table: "Claims",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionOfWork",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "HoursWorked",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "RatePerHour",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Claims");
        }
    }
}
