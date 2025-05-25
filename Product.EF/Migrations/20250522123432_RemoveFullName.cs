using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.EF.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFullDataTBL",
                schema: "Prod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductFullDataTBL",
                schema: "Prod",
                columns: table => new
                {
                    FullNameID = table.Column<string>(type: "TEXT", nullable: false),
                    ProdID = table.Column<string>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FullCode = table.Column<string>(type: "TEXT", nullable: false),
                    PropCode = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false),
                    RegistTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserLogID = table.Column<string>(type: "TEXT", nullable: false),
                    ValueCode = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFullDataTBL", x => x.FullNameID);
                    table.ForeignKey(
                        name: "FK_ProductFullDataTBL_ProductTBL_ProdID",
                        column: x => x.ProdID,
                        principalSchema: "Prod",
                        principalTable: "ProductTBL",
                        principalColumn: "ProdID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductFullDataTBL_FullCode",
                schema: "Prod",
                table: "ProductFullDataTBL",
                column: "FullCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductFullDataTBL_ProdID",
                schema: "Prod",
                table: "ProductFullDataTBL",
                column: "ProdID");
        }
    }
}
