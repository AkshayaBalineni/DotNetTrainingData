using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnEFLayer.Migrations
{
    public partial class addBankOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IFSC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankId);
                });

           /* migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    categoryid = table.Column<int>(type: "int", nullable: false),
                    category = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.categoryid);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    companyid = table.Column<int>(type: "int", nullable: false),
                    companyname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    companystatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    isdeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.companyid);
                });*/

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK_Offers_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

           /* migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    pid = table.Column<int>(type: "int", nullable: false),
                    productname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    price = table.Column<double>(type: "float", nullable: true),
                    companyid = table.Column<int>(type: "int", nullable: true),
                    categoryid = table.Column<int>(type: "int", nullable: true),
                    availablestatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    imageUrl = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__product__DD37D91A44BAD04F", x => x.pid);
                    table.ForeignKey(
                        name: "fk_category_caid",
                        column: x => x.categoryid,
                        principalTable: "category",
                        principalColumn: "categoryid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_company_id",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });*/

            migrationBuilder.CreateIndex(
                name: "IX_Offers_BankId",
                table: "Offers",
                column: "BankId");

            /*migrationBuilder.CreateIndex(
                name: "IX_product_categoryid",
                table: "product",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_product_companyid",
                table: "product",
                column: "companyid");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");

           /* migrationBuilder.DropTable(
                name: "product");*/

            migrationBuilder.DropTable(
                name: "Banks");

          /*  migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "company");*/
        }
    }
}
