using Microsoft.EntityFrameworkCore;
using PizzaApi.Models;

namespace PizzaApi;

public class PizzaDbContext : DbContext
{
    public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
    {
 
    }
    public DbSet<Pizza> Pizzas { get; set; }
}