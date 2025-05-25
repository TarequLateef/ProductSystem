using Microsoft.EntityFrameworkCore.Migrations;
using Product.Core.DbStructs;

#nullable disable

namespace Product.EF.Migrations
{
    /// <inheritdoc />
    public partial class updatePropMeasure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackgeNo",
                schema: "Prod",
                table: "PropValTBL");

            migrationBuilder.AlterColumn<string>(
                name: "PropID",
                schema: "Prod",
                table: "PropValTBL",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "PackgeName",
                schema: "Prod",
                table: "PropValTBL",
                type: "TEXT",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PropID",
                schema: "Prod",
                table: "PropertyTBL",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTBL_PropMeasure",
                schema: "Prod",
                table: GoodTables.Properties,
                columns: new[] { "PropName", "MeasureID" },
                unique: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackgeName",
                schema: "Prod",
                table: "PropValTBL");

            migrationBuilder.AlterColumn<int>(
                name: "PropID",
                schema: "Prod",
                table: "PropValTBL",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<byte>(
                name: "PackgeNo",
                schema: "Prod",
                table: "PropValTBL",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<int>(
                name: "PropID",
                schema: "Prod",
                table: "PropertyTBL",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.DropIndex("IX_PropertyTBL_PropMeasure");
        }
    }
}
