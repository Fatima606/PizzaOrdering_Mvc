using Microsoft.EntityFrameworkCore;
using PizzaOrdering_Mvc.Models;

namespace PizzaOrdering_Mvc.PizzaApp_DbContext
{
    public class PizzaAppDbContext:DbContext
    {
        public PizzaAppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Size> Size { get; set; }
        public DbSet<Base> Base { get; set; }
        public DbSet<Toppings> Toppings { get; set; }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<PizzaTopping> PizzaTopping { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Size>().HasData(
                new Size() { SizeId = Guid.NewGuid(), PizzaSize = "Large" },
                new Size() { SizeId = Guid.NewGuid(), PizzaSize = "Medium" },
                new Size() { SizeId = Guid.NewGuid(), PizzaSize = "Small" }
                );
            modelBuilder.Entity<Base>().HasData(
                 new Base() { baseId = Guid.NewGuid(), BaseName = "Thick" },
                 new Base() { baseId = Guid.NewGuid(), BaseName = "Thin" }
                 );
            modelBuilder.Entity<Toppings>().HasData(
                 new Toppings() { ToppingId = Guid.NewGuid(), ToppingName = "Chicken" },
                 new Toppings() { ToppingId = Guid.NewGuid(), ToppingName = "Pepperoni" },
                 new Toppings() { ToppingId = Guid.NewGuid(), ToppingName = "Extra Cheese" },
                 new Toppings() { ToppingId = Guid.NewGuid(), ToppingName = "Mushroom" },
                 new Toppings() { ToppingId = Guid.NewGuid(), ToppingName = "Spinach" },
                 new Toppings() { ToppingId = Guid.NewGuid(), ToppingName = "Olives" }
                 );

            modelBuilder.Entity<PizzaTopping>()
                .HasKey(pt => new { pt.PizzaId, pt.ToppingId });

        }
    }
}
