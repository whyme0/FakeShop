using FakeShop.Data.Configuration;
using FakeShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FakeShop.Data
{
    public class ShopDbContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .Property(u => u.Sex).HasConversion<int>();

            builder.Entity<User>(b => b.ToTable("Users"));
            builder.Entity<IdentityRole>(b => b.ToTable("Roles"));
            builder.Entity<IdentityRoleClaim<string>>(b => b.ToTable("RoleClaims"));
            builder.Entity<IdentityUserClaim<string>>(b => b.ToTable("UserClaims"));
            builder.Entity<IdentityUserToken<string>>(b => b.ToTable("Tokens"));
            builder.Entity<IdentityUserLogin<string>>(b => b.ToTable("UserLogins"));
            builder.Entity<IdentityUserRole<string>>(b => b.ToTable("UserRoles"));

            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}