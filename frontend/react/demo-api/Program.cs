using BrawlstarsApi.Models;
using Microsoft.AspNetCore.Http.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/brawler", (HttpRequest request, HttpResponse response) =>
{
    return Results.Ok(new List<Brawler>());
});

app.MapDelete("/brawler", (HttpRequest request, HttpResponse response) =>
{
    return new List<Brawler>();
});

app.MapPost("/brawler", (HttpContext context, Brawler brawler) =>
{
    return Results.Created($"{context.Request.GetDisplayUrl()}/{brawler.ID}", brawler);
});

app.Run();
