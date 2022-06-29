using Microsoft.AspNetCore.Mvc;
using PizzaApi.Models;
using PizzaApi.Services;

namespace PizzaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly IPizzaService _pizzaService;
    public PizzaController(IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pizzas = await _pizzaService.GetAll();
        return Ok(pizzas);
    } 

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var pizza = await _pizzaService.Get(id);
        if (pizza == null)
            return NotFound();
        return Ok(pizza);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Pizza pizza)
    {
        await _pizzaService.Add(pizza);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();
        await _pizzaService.Update(pizza);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _pizzaService.Delete(id);
        return NoContent();
    }
}