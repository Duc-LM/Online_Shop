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
        public virtual DbSet<Delivery_status> Delivery_status { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_Product> Order_Product { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.category_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Delivery_status>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Delivery_status)
                .HasForeignKey(e => e.delivery_status_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.payment_method)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.total_price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.ship_price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order_Product>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order_Product>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Order_Product)
                .HasForeignKey(e => e.cart_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.short_desc)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.images)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.cpu)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.gpu)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.screen)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.storage)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ram)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.os)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.size)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.weight)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ports)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.connectivity)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.battery)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.extras)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.manufacturer)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Order_Product)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.product_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Promotion>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Promotion>()
                .Property(e => e.percent_discount)
                .IsFixedLength();

            modelBuilder.Entity<Promotion>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Promotion)
                .HasForeignKey(e => e.promotion_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.role_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.user_name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.avatar)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.creator_id);
        }
    }
}
