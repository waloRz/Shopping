using Microsoft.EntityFrameworkCore;
using Shopping.Data.Entities;

namespace Shopping.Data
{
    public class DataContext : DbContext
    {
        //DbContextOptions(Clase Generica)
        //al colocar :base(options) le paso el option a la clase padre en este caso al DbContext
        public DataContext(DbContextOptions<DataContext>options) : base(options) 
        {
        }
        
        public DbSet<Category> Categories{ get; set; } //el DbSet mapea las entidades
        public DbSet<Country> Countries { get; set; } //el DbSet mapea las entidades

        // sirve para modificar la base de datos
        //crear los indices
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
        }
    }
}
