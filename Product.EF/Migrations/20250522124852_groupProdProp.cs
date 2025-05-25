using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.EF.Migrations
{
    /// <inheritdoc />
    public partial class groupProdProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "PackgeNo",
                schema: "Prod",
                table: "PropValTBL",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "ProductFullDataTBL",
                schema: "Prod",
                columns: table => new
                {
                    FullDataID = table.Column<string>(type: "TEXT", nullable: false),
                    ProdID = table.Column<string>(type: "TEXT", nullable: false),
                    PropCode = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false),
                    ValueCode = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    FullCode = table.Column<string>(type: "TEXT", nullable: false),
                    UserLogID = table.Column<string>(type: "TEXT", nullable: false),
                    RegistTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFullDataTBL", x => x.FullDataID);
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFullDataTBL",
                schema: "Prod");

            migrationBuilder.DropColumn(
                name: "PackgeNo",
                schema: "Prod",
                table: "PropValTBL");
        }
    }
}
