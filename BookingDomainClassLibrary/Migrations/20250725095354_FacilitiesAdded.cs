using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingDomainClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class FacilitiesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentFacility_Facility_FacilitiesId",
                table: "ApartmentFacility");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_ShopUserId1",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ShopUserId1",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facility",
                table: "Facility");

            migrationBuilder.DropColumn(
                name: "ShopUserId1",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Facility",
                newName: "Facilities");

            migrationBuilder.AlterColumn<string>(
                name: "ShopUserId",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facilities",
                table: "Facilities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ShopUserId",
                table: "Reviews",
                column: "ShopUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentFacility_Facilities_FacilitiesId",
                table: "ApartmentFacility",
                column: "FacilitiesId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_ShopUserId",
                table: "Reviews",
                column: "ShopUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentFacility_Facilities_FacilitiesId",
                table: "ApartmentFacility");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_ShopUserId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ShopUserId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facilities",
                table: "Facilities");

            migrationBuilder.RenameTable(
                name: "Facilities",
                newName: "Facility");

            migrationBuilder.AlterColumn<int>(
                name: "ShopUserId",
                table: "Reviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ShopUserId1",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facility",
                table: "Facility",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ShopUserId1",
                table: "Reviews",
                column: "ShopUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentFacility_Facility_FacilitiesId",
                table: "ApartmentFacility",
                column: "FacilitiesId",
                principalTable: "Facility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_ShopUserId1",
                table: "Reviews",
                column: "ShopUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
