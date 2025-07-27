using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingDomainClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class ReviewsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApartmentId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ApartmentId",
                table: "Reviews",
                column: "ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Apartments_ApartmentId",
                table: "Reviews",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Apartments_ApartmentId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ApartmentId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "Reviews");
        }
    }
}
