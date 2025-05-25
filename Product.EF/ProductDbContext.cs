using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Product.Core.DbStructs;
using Product.Core.Models.ProdSch;
using SharedLiberary.Models.UserManagment;

namespace Product.EF
{
    public class ProductDbContext : IdentityDbContext<ApplicationUser>
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder
            { DataSource = "Product_DB.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connect = new SqliteConnection(connectionString);
            optionsBuilder.UseSqlite(connect, b => b.MigrationsAssembly("Product.EF"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users", schema: UserSchema.Secure);
            builder.Entity<IdentityRole>().ToTable("Roles", schema: UserSchema.Secure);
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", schema: UserSchema.Secure);
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", schema: UserSchema.Secure);
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", schema: UserSchema.Secure);
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", schema: UserSchema.Secure);

            builder.Entity<ApplicationUser>()
                .OwnsMany(x => x.RefrshTokens, a =>
                {
                    a.WithOwner().HasForeignKey("UserId");
                    a.Property<int>("Id");
                    a.HasKey("Id", "UserId");
                    a.ToTable("RefreshTokens");
                });

            builder.Entity<Products>().HasIndex(p => p.ProdName).IsUnique();
            builder.Entity<Products>().HasIndex(p=>p.BaseCode).IsUnique();

            builder.Entity<Property>().HasIndex(p=>p.PropName).IsUnique();
            builder.Entity<Property>().HasIndex(p => p.PropCode).IsUnique();

            builder.Entity<PropValue>().HasIndex(p => p.ProprityValue).IsUnique();
            builder.Entity<PropValue>().HasIndex(p => p.ValCode).IsUnique();

            builder.Entity<ProductFullData>().HasIndex(p => p.FullCode).IsUnique();

            builder.Entity<Measurment>().HasIndex(m => m.MeasureCode).IsUnique();
        }


        #region Product Schema
        public DbSet<Products> Products { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropValue> PropValues { get; set; }
        public DbSet<ProductFullData> ProductFullDatas { get; set; }
        public DbSet<Measurment> Measurments { get; set; }
        #endregion
    }
}
