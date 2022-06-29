using PizzaApi.Models;

namespace PizzaApi.Services;

public interface IPizzaService
{
    public Task<List<Pizza>> GetAll();
    public Task<Pizza?> Get(int id);
    public Task Add(Pizza pizza);
    public Task Delete(int id);
    public Task Update(Pizza pizza);

}