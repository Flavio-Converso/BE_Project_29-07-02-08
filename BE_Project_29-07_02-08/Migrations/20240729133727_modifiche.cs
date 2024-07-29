using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_Project_29_07_02_08.Migrations
{
    /// <inheritdoc />
    public partial class modifiche : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientProduct_Ingredients_IngredientsId",
                table: "IngredientProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientProduct_Products_ProductsId",
                table: "IngredientProduct");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "IdProduct");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ingredients",
                newName: "IdIngredient");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "IngredientProduct",
                newName: "ProductsIdProduct");

            migrationBuilder.RenameColumn(
                name: "IngredientsId",
                table: "IngredientProduct",
                newName: "IngredientsIdIngredient");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientProduct_ProductsId",
                table: "IngredientProduct",
                newName: "IX_IngredientProduct_ProductsIdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientProduct_Ingredients_IngredientsIdIngredient",
                table: "IngredientProduct",
                column: "IngredientsIdIngredient",
                principalTable: "Ingredients",
                principalColumn: "IdIngredient",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientProduct_Products_ProductsIdProduct",
                table: "IngredientProduct",
                column: "ProductsIdProduct",
                principalTable: "Products",
                principalColumn: "IdProduct",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientProduct_Ingredients_IngredientsIdIngredient",
                table: "IngredientProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientProduct_Products_ProductsIdProduct",
                table: "IngredientProduct");

            migrationBuilder.RenameColumn(
                name: "IdProduct",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdIngredient",
                table: "Ingredients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductsIdProduct",
                table: "IngredientProduct",
                newName: "ProductsId");

            migrationBuilder.RenameColumn(
                name: "IngredientsIdIngredient",
                table: "IngredientProduct",
                newName: "IngredientsId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientProduct_ProductsIdProduct",
                table: "IngredientProduct",
                newName: "IX_IngredientProduct_ProductsId");

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientProduct_Ingredients_IngredientsId",
                table: "IngredientProduct",
                column: "IngredientsId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientProduct_Products_ProductsId",
                table: "IngredientProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
