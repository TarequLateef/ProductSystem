using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.EF.Migrations
{
    /// <inheritdoc />
    public partial class updatePropMeasureRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTBL_MeasureUnitTBL_MeasureID",
                schema: "Prod",
                table: "PropertyTBL");

            migrationBuilder.DropIndex(
                name: "IX_PropertyTBL_MeasureID",
                schema: "Prod",
                table: "PropertyTBL");

            migrationBuilder.DropIndex(
                name: "IX_PropertyTBL_PropFullCode",
                schema: "Prod",
                table: "PropertyTBL");

            migrationBuilder.DropColumn(
                name: "MeasureID",
                schema: "Prod",
                table: "PropertyTBL");

            migrationBuilder.DropColumn(
                name: "PropFullCode",
                schema: "Prod",
                table: "PropertyTBL");

            migrationBuilder.AddColumn<string>(
                name: "PropFullCode",
                schema: "Prod",
                table: "MeasureUnitTBL",
                type: "TEXT",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PropID",
                schema: "Prod",
                table: "MeasureUnitTBL",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MeasureUnitTBL_PropID",
                schema: "Prod",
                table: "MeasureUnitTBL",
                column: "PropID");

            migrationBuilder.AddForeignKey(
                name: "FK_MeasureUnitTBL_PropertyTBL_PropID",
                schema: "Prod",
                table: "MeasureUnitTBL",
                column: "PropID",
                principalSchema: "Prod",
                principalTable: "PropertyTBL",
                principalColumn: "PropID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.CreateIndex(
                name: "IX_MeasureUnitTBL_PropFullCode",
                schema: "Prod",
                table: "MeasureUnitTBL",
                column: "PropFullCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeasureUnitTBL_PropertyTBL_PropID",
                schema: "Prod",
                table: "MeasureUnitTBL");

            migrationBuilder.DropIndex(
                name: "IX_MeasureUnitTBL_PropID",
                schema: "Prod",
                table: "MeasureUnitTBL");

            migrationBuilder.DropColumn(
                name: "PropFullCode",
                schema: "Prod",
                table: "MeasureUnitTBL");

            migrationBuilder.DropColumn(
                name: "PropID",
                schema: "Prod",
                table: "MeasureUnitTBL");

            migrationBuilder.AddColumn<string>(
                name: "MeasureID",
                schema: "Prod",
                table: "PropertyTBL",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropFullCode",
                schema: "Prod",
                table: "PropertyTBL",
                type: "TEXT",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTBL_MeasureID",
                schema: "Prod",
                table: "PropertyTBL",
                column: "MeasureID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTBL_PropFullCode",
                schema: "Prod",
                table: "PropertyTBL",
                column: "PropFullCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyTBL_MeasureUnitTBL_MeasureID",
                schema: "Prod",
                table: "PropertyTBL",
                column: "MeasureID",
                principalSchema: "Prod",
                principalTable: "MeasureUnitTBL",
                principalColumn: "MeasureID");

            migrationBuilder.DropIndex(
                name: "IX_MeasureUnitTBL_PropFullCode",
                schema: "Prod",
                table: "MeasureUnitTBL");
        }
    }
}
