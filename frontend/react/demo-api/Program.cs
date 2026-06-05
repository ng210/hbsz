using BrawlstarsApi.Models;
using DemoApi.Models;
using Microsoft.AspNetCore.Http.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(o => o.AddPolicy(
    "AllowAll",
    policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()));

Context _context = new("brawlstars.json");

var app = builder.Build();
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.MapPost("/brawler", (HttpContext context, Brawler brawler) =>
{
    if (_context.Brawlers.Any(b => b.ID == brawler.ID || b.Name == brawler.Name))
    {
        return Results.BadRequest();
    }
    _context.Brawlers.Add(brawler);
    return Results.Created($"{context.Request.GetDisplayUrl()}/{brawler.ID}", brawler);
});

app.MapGet("/brawler", (HttpRequest request) =>
{
    return Results.Ok(_context.Brawlers);
});

app.MapGet("/brawler/{id:int}", (HttpRequest request, int id) =>
{
    var brawler = _context.Brawlers.FirstOrDefault(b => b.ID == id);

    return Results.Ok(brawler);
});

app.MapPut("/brawler", (HttpContext context, int id, Brawler brawler) =>
{
    return Results.Created($"{context.Request.GetDisplayUrl()}/{brawler.ID}", brawler);
});


app.MapDelete("/brawler/{id:int}", (HttpRequest request, int id) =>
{
    var brawler = _context.Brawlers.FirstOrDefault(b => b.ID == id);
    if (brawler == null) return Results.NotFound();
    _context.Brawlers.Remove(brawler);
    return Results.NoContent();
});


app.Run();
