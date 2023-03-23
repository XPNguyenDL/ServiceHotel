using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixInvoiceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Invoices_RoomId",
                table: "Invoices",
                column: "RoomId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Room_RoomId",
                table: "Invoices",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Room_RoomId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_RoomId",
                table: "Invoices");
        }
    }
}
