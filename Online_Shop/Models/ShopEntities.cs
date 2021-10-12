namespace Online_Shop.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopEntities : DbContext
    {
        public ShopEntities()
            : base("name=ShopEntities")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_Product> Order_Product { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Spec> Specs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.Category_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Total_price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.Delivery_status)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Ship_price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order_Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order_Product>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Order_Product)
                .HasForeignKey(e => e.Cart_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Order_Product)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.Product_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Specs)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.Product_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Promotion>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Promotion)
                .HasForeignKey(e => e.Promotion_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.Role_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.Creator_id);
        }
    }
}
