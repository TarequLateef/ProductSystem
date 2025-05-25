using Microsoft.EntityFrameworkCore.Migrations;
using Product.Core.DbStructs;

#nullable disable

namespace Product.EF.Migrations
{
    /// <inheritdoc />
    public partial class InsertRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            RolesList rl = new RolesList(Roles.Administrator);
            migrationBuilder.InsertData(UserTables.Roles,
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), rl.Role, rl.Role.ToUpper(), Guid.NewGuid().ToString() }, UserSchema.Secure);

            rl = new RolesList(Roles.SuperVisor);
            migrationBuilder.InsertData(UserTables.Roles,
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), rl.Role, rl.Role.ToUpper(), Guid.NewGuid().ToString() }, UserSchema.Secure);

            rl = new RolesList(Roles.User);
            migrationBuilder.InsertData(UserTables.Roles,
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), rl.Role, rl.Role.ToUpper(), Guid.NewGuid().ToString() }, UserSchema.Secure);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
