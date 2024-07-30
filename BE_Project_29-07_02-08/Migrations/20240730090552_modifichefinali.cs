using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_Project_29_07_02_08.Migrations
{
    /// <inheritdoc />
    public partial class modifichefinali : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveryTime",
                table: "Products",
                newName: "DeliveryTimeMin");

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalNotes",
                table: "Orders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveryTimeMin",
                table: "Products",
                newName: "DeliveryTime");

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalNotes",
                table: "Orders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}
