using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.EF.Migrations
{
    /// <inheritdoc />
    public partial class WithoutRegister : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistTime",
                schema: "Prod",
                table: "PropValTBL");

            migrationBuilder.DropColumn(
                name: "UserLogID",
                schema: "Prod",
                table: "PropValTBL");

            migrationBuilder.DropColumn(
                name: "RegistTime",
                schema: "Prod",
                table: "PropertyTBL");

            migrationBuilder.DropColumn(
                name: "UserLogID",
                schema: "Prod",
                table: "PropertyTBL");

            migrationBuilder.DropColumn(
                name: "RegistTime",
                schema: "Prod",
                table: "ProductTBL");

            migrationBuilder.DropColumn(
                name: "UserLogID",
                schema: "Prod",
                table: "ProductTBL");

            migrationBuilder.DropColumn(
                name: "RegistTime",
                schema: "Prod",
                table: "ProductFullDataTBL");

            migrationBuilder.DropColumn(
                name: "UserLogID",
                schema: "Prod",
                table: "ProductFullDataTBL");

            migrationBuilder.DropColumn(
                name: "RegistTime",
                schema: "Prod",
                table: "MeasureUnitTBL");

            migrationBuilder.DropColumn(
                name: "UserLogID",
                schema: "Prod",
                table: "MeasureUnitTBL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegistTime",
                schema: "Prod",
                table: "PropValTBL",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserLogID",
                schema: "Prod",
                table: "PropValTBL",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistTime",
                schema: "Prod",
                table: "PropertyTBL",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserLogID",
                schema: "Prod",
                table: "PropertyTBL",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistTime",
                schema: "Prod",
                table: "ProductTBL",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserLogID",
                schema: "Prod",
                table: "ProductTBL",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistTime",
                schema: "Prod",
                table: "ProductFullDataTBL",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserLogID",
                schema: "Prod",
                table: "ProductFullDataTBL",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistTime",
                schema: "Prod",
                table: "MeasureUnitTBL",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserLogID",
                schema: "Prod",
                table: "MeasureUnitTBL",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
