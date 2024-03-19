using crudemvccore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace crudemvccore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Todotask> Todotasks { get; set; }
        public DbSet<crudemvccore.Models.Login> Login { get; set; }
        public DbSet<crudemvccore.Models.Product> Product { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Orderproduct> orderproducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship between Product and Category using Fluent API
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)               // A Product has one Category
                .WithMany(c => c.Products)             // A Category can have many Products
                .HasForeignKey(p => p.CategoryId);    // Define the foreign key property in Product

            // Optionally, configure any additional constraints or behaviors here

            base.OnModelCreating(modelBuilder);
        }

    }
}
