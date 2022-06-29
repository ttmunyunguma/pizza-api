using Microsoft.EntityFrameworkCore;
using PizzaApi.Models;

namespace PizzaApi.Services;

public class PizzaService : IPizzaService
{
    private PizzaDbContext _db;

    public PizzaService(PizzaDbContext db)
    {
        _db = db;
    }

    public async Task<List<Pizza>> GetAll()
    {
        return await _db.Pizzas.ToListAsync();
    }
    
    public async Task<Pizza?> Get(int id)
    {
        return await _db.Pizzas.FindAsync(id);
    } 

    public async Task Add(Pizza pizza)
    {
        await _db.Pizzas.AddAsync(pizza);
    }

    public async Task Delete(int id)
    {
        var pizza = await _db.Pizzas.FindAsync(id);
        if (pizza != null)
        {
            _db.Pizzas.Remove(pizza);
        }
    }

    public async Task Update(Pizza pizza)
    {
        var toUpdatePizza = await _db.Pizzas.FindAsync(pizza.Id);
        if (toUpdatePizza != null)
        {
            toUpdatePizza.Name = pizza.Name;
            toUpdatePizza.IsGlutenFree = pizza.IsGlutenFree;
            await _db.SaveChangesAsync();
        }
    }
}
