namespace Online_Shop.Models
{
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;

    public partial class ShopEntities : DbContext
    {
        public ShopEntities()
            : base("name=ShopEntities")
        {
        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.PropertyName + ": " + x.ErrorMessage));
                throw new DbEntityValidationException(errorMessages);
            }
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

            modelBuilder.Entity<Order>()
                .Property(e => e.Total_Price)
                .HasPrecision(18, 0);

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
                .HasMany(e => e.Specs)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.Product_id);

            modelBuilder.Entity<Promotion>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Promotion)
                .HasForeignKey(e => e.Promotion_id);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Role)
                .HasForeignKey(e => e.Role_id);

            modelBuilder.Entity<User>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Order_Product)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_id);
        }
    }
}
