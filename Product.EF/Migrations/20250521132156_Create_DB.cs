using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.EF.Migrations
{
    /// <inheritdoc />
    public partial class Create_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Prod");

            migrationBuilder.EnsureSchema(
                name: "Secure");

            migrationBuilder.CreateTable(
                name: "MeasureUnitTBL",
                schema: "Prod",
                columns: table => new
                {
                    MeasureID = table.Column<string>(type: "TEXT", nullable: false),
                    MeasureName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    MeasureShort = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    MeasureCode = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    UserLogID = table.Column<string>(type: "TEXT", nullable: false),
                    RegistTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureUnitTBL", x => x.MeasureID);
                });

            migrationBuilder.CreateTable(
                name: "ProductTBL",
                schema: "Prod",
                columns: table => new
                {
                    ProdID = table.Column<string>(type: "TEXT", nullable: false),
                    ProdName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    ProdDesc = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    BaseCode = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    UserLogID = table.Column<string>(type: "TEXT", nullable: false),
                    RegistTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTBL", x => x.ProdID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Secure",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Secure",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTBL",
                schema: "Prod",
                columns: table => new
                {
                    PropID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropName = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    PropDesc = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    PropCode = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    MeasureID = table.Column<string>(type: "TEXT", nullable: true),
                    PropFullCode = table.Column<string>(type: "TEXT", maxLength: 6, nullable: false),
                    UserLogID = table.Column<string>(type: "TEXT", nullable: false),
                    RegistTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTBL", x => x.PropID);
                    table.ForeignKey(
                        name: "FK_PropertyTBL_MeasureUnitTBL_MeasureID",
                        column: x => x.MeasureID,
                        principalSchema: "Prod",
                        principalTable: "MeasureUnitTBL",
                        principalColumn: "MeasureID");
                });

            migrationBuilder.CreateTable(
                name: "ProductFullDataTBL",
                schema: "Prod",
                columns: table => new
                {
                    FullNameID = table.Column<string>(type: "TEXT", nullable: false),
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
                    table.PrimaryKey("PK_ProductFullDataTBL", x => x.FullNameID);
                    table.ForeignKey(
                        name: "FK_ProductFullDataTBL_ProductTBL_ProdID",
                        column: x => x.ProdID,
                        principalSchema: "Prod",
                        principalTable: "ProductTBL",
                        principalColumn: "ProdID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Secure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Secure",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Secure",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                schema: "Secure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Token = table.Column<string>(type: "TEXT", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RevokedOn = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => new { x.Id, x.UserId });
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Secure",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Secure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Secure",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Secure",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Secure",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Secure",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Secure",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Secure",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropValTBL",
                schema: "Prod",
                columns: table => new
                {
                    PropValID = table.Column<string>(type: "TEXT", nullable: false),
                    ProdID = table.Column<string>(type: "TEXT", nullable: false),
                    PropID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProprityValue = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    ValCode = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    UserLogID = table.Column<string>(type: "TEXT", nullable: false),
                    RegistTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropValTBL", x => x.PropValID);
                    table.ForeignKey(
                        name: "FK_PropValTBL_ProductTBL_ProdID",
                        column: x => x.ProdID,
                        principalSchema: "Prod",
                        principalTable: "ProductTBL",
                        principalColumn: "ProdID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropValTBL_PropertyTBL_PropID",
                        column: x => x.PropID,
                        principalSchema: "Prod",
                        principalTable: "PropertyTBL",
                        principalColumn: "PropID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasureUnitTBL_MeasureCode",
                schema: "Prod",
                table: "MeasureUnitTBL",
                column: "MeasureCode",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductTBL_BaseCode",
                schema: "Prod",
                table: "ProductTBL",
                column: "BaseCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTBL_ProdName",
                schema: "Prod",
                table: "ProductTBL",
                column: "ProdName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTBL_MeasureID",
                schema: "Prod",
                table: "PropertyTBL",
                column: "MeasureID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTBL_PropCode",
                schema: "Prod",
                table: "PropertyTBL",
                column: "PropCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTBL_PropFullCode",
                schema: "Prod",
                table: "PropertyTBL",
                column: "PropFullCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTBL_PropName",
                schema: "Prod",
                table: "PropertyTBL",
                column: "PropName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropValTBL_ProdID",
                schema: "Prod",
                table: "PropValTBL",
                column: "ProdID");

            migrationBuilder.CreateIndex(
                name: "IX_PropValTBL_PropID",
                schema: "Prod",
                table: "PropValTBL",
                column: "PropID");

            migrationBuilder.CreateIndex(
                name: "IX_PropValTBL_ProprityValue",
                schema: "Prod",
                table: "PropValTBL",
                column: "ProprityValue",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropValTBL_ValCode",
                schema: "Prod",
                table: "PropValTBL",
                column: "ValCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                schema: "Secure",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Secure",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Secure",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Secure",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Secure",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Secure",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Secure",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "ProductFullDataTBL",
                schema: "Prod");

            migrationBuilder.DropTable(
                name: "PropValTBL",
                schema: "Prod");

            migrationBuilder.DropTable(
                name: "RefreshTokens",
                schema: "Secure");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Secure");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Secure");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Secure");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Secure");

            migrationBuilder.DropTable(
                name: "ProductTBL",
                schema: "Prod");

            migrationBuilder.DropTable(
                name: "PropertyTBL",
                schema: "Prod");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Secure");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Secure");

            migrationBuilder.DropTable(
                name: "MeasureUnitTBL",
                schema: "Prod");
        }
    }
}
