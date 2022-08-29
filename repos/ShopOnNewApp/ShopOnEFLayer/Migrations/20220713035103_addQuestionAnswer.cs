using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnEFLayer.Migrations
{
    public partial class addQuestionAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerQueries",
                columns: table => new
                {
                    CustomerQueryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateOfQuery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerQueries", x => x.CustomerQueryId);
                    table.ForeignKey(
                        name: "FK_CustomerQueries_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "pid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerQueryAnswer",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    QuestionForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerQueryAnswer", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_CustomerQueryAnswer_CustomerQueries_QuestionForeignKey",
                        column: x => x.QuestionForeignKey,
                        principalTable: "CustomerQueries",
                        principalColumn: "CustomerQueryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerQueries_ProductId",
                table: "CustomerQueries",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerQueryAnswer_QuestionForeignKey",
                table: "CustomerQueryAnswer",
                column: "QuestionForeignKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerQueryAnswer");

            migrationBuilder.DropTable(
                name: "CustomerQueries");
        }
    }
}
