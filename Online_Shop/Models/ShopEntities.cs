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
        public virtual DbSet<Spec> Specs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.Category_id);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products1)
                .WithOptional(e => e.Category1)
                .HasForeignKey(e => e.Category_id);

            modelBuilder.Entity<Order>()
                .Property(e => e.Total_price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.Delivery_status)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Ship_price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Order_Product)
                .WithOptional(e => e.Order)
                .HasForeignKey(e => e.Order_id);

            modelBuilder.Entity<Order_Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Order_Product)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.Product_id);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Order_Product1)
                .WithOptional(e => e.Product1)
                .HasForeignKey(e => e.Product_id);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Specs)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.Product_id);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Specs1)
                .WithOptional(e => e.Product1)
                .HasForeignKey(e => e.Product_id);

            modelBuilder.Entity<Promotion>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Promotion)
                .HasForeignKey(e => e.Promotion_id);

            modelBuilder.Entity<Promotion>()
                .HasMany(e => e.Orders1)
                .WithOptional(e => e.Promotion1)
                .HasForeignKey(e => e.Promotion_id);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Role)
                .HasForeignKey(e => e.Role_id);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users1)
                .WithOptional(e => e.Role1)
                .HasForeignKey(e => e.Role_id);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Order_Product)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Order_Product1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.User_id);
        }
    }
}
