using InventarioAPI.Data;
using InventarioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Controllers;

[ApiController]
[Route("api/articulos")]
public class ArticuloController : ControllerBase
{
    private ApplicationDbContext Context { get; }
    
    public ArticuloController(ApplicationDbContext context)
    {
        Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Articulo>>> Get()
    {
        return await Context.Articulos.ToListAsync();
    }
    
    [HttpPost]
    public async Task<ActionResult> Post(Articulo articulo)
    {
        Context.Articulos.Add(articulo);
        if (await Context.SaveChangesAsync() > 0) return Ok();
        return BadRequest();
    }
    
    [HttpPut]
    public async Task<ActionResult> Put(Articulo articulo)
    {
        Context.Articulos.Update(articulo);
        if (await Context.SaveChangesAsync() > 0) return Ok();
        return BadRequest();
    }
    
    [HttpDelete]
    public async Task<ActionResult> Delete(Articulo articulo)
    {
        Context.Articulos.Remove(articulo);
        if (await Context.SaveChangesAsync() > 0) return Ok();
        return BadRequest();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Articulo>> Get(int id)
    {
        return (await Context.Articulos.FirstOrDefaultAsync(x => x.Id == id))!;
    }
}