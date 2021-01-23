using Microsoft.EntityFrameworkCore.Migrations;

namespace FluentAPI.Migrations
{
    public partial class Change_Vendor_to_VendorFluentApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_vendors_VendorId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vendors",
                table: "vendors");

            migrationBuilder.RenameTable(
                name: "vendors",
                newName: "VendorFluentApi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendorFluentApi",
                table: "VendorFluentApi",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_VendorFluentApi_VendorId",
                table: "Tags",
                column: "VendorId",
                principalTable: "VendorFluentApi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_VendorFluentApi_VendorId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VendorFluentApi",
                table: "VendorFluentApi");

            migrationBuilder.RenameTable(
                name: "VendorFluentApi",
                newName: "vendors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vendors",
                table: "vendors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_vendors_VendorId",
                table: "Tags",
                column: "VendorId",
                principalTable: "vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
