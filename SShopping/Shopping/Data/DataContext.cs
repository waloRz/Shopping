using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shopping.Data.Entities;

namespace Shopping.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        //DbContextOptions(Clase Generica)
        //al colocar :base(options) le paso el option a la clase padre en este caso al DbContext
        public DataContext(DbContextOptions<DataContext>options) : base(options) 
        {
        }
        
        public DbSet<Category> Categories { get; set; } //el DbSet mapea las entidades
        public DbSet<City> Cities { get; set; } //el DbSet mapea las entidades
        public DbSet<Country> Countries { get; set; } //el DbSet mapea las entidades
        public DbSet<State> States { get; set; } //el DbSet mapea las entidades
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        // sirve para modificar la base de datos
        //crear los indices
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique(); //No permite repertir los nombres de provincia en el pais
            modelBuilder.Entity<City>().HasIndex("Name", "StateId").IsUnique(); //No permite repertir los nombres de la ciudad por provincia
            modelBuilder.Entity<Product>().HasIndex(c => c.Name ).IsUnique();
            modelBuilder.Entity<ProductCategory>().HasIndex("ProductId", "CategoryId").IsUnique(); //No permite repertir los nombres de la ciudad por provincia
        }
    }
}
