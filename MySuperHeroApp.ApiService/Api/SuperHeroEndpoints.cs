using Microsoft.EntityFrameworkCore;
using MySuperHeroApp.ApiService.Database;
using MySuperHeroApp.ApiService.Model;
using MySuperHeroApp.ApiService.Workers;

namespace MySuperHeroApp.ApiService.Api
{
    public static class SuperHeroEndpoints
    {
        public static void MapSuperHeroEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/superheroes", async (SuperHeroDbContext db) =>
            {
                return await db.SuperHeroes.ToListAsync();
            })
            .WithName("GetAllSuperHeroes")
            .Produces<List<SuperHero>>(StatusCodes.Status200OK);

            routes.MapGet("/api/superheroes/{id}", async (string id, SuperHeroDbContext db) =>
            {
                return await db.SuperHeroes.FindAsync(id)
                    is SuperHero hero
                        ? Results.Ok(hero)
                        : Results.NotFound();
            })
            .WithName("GetSuperHeroById")
            .Produces<SuperHero>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            routes.MapGet("/api/superheroes/sync/{id}", async (string id, IAddSuperHeroTask addSuperHeroTask) =>
            {
                await addSuperHeroTask.AddSupperHeroToDbTask(id.ToString(), CancellationToken.None);
                return Results.Accepted();
            })
            .WithName("AddSuperHeroById")
            .Produces<SuperHero>(StatusCodes.Status202Accepted);

            routes.MapGet("/api/superheroes/sync", async (IAddSuperHeroTask addSuperHeroTask) =>
            {
                for (int i = 1; i <= 731; i++)
                {
                    await addSuperHeroTask.AddSupperHeroToDbTask(i.ToString(), CancellationToken.None);
                }

                return Results.Accepted();
            })
           .WithName("AddSuperHeroes")
           .Produces<SuperHero>(StatusCodes.Status202Accepted);

            routes.MapGet("/api/superheroes/image/{id}", async (string id) =>
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "image");
                if (!Directory.Exists(path))
                {
                    return Results.NotFound();
                }
                var filePath = Path.Combine(path, $"{id}.jpg");
                if (!System.IO.File.Exists(filePath))
                {
                    filePath = Path.Combine(path, $"0.png");
                }

                try
                {
                    var contentType = GetContentType(filePath);

                    // Read the file as a byte array
                    var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);

                    // Return the file as a response
                    return Results.File(fileBytes, contentType);
                }
                catch (Exception)
                {
                    return Results.StatusCode(StatusCodes.Status500InternalServerError); // Return a 500 error in case of an exception.
                }
            })
          .WithName("GetSuperHeroImage")
          .Produces<SuperHero>(StatusCodes.Status200OK)
          .Produces(StatusCodes.Status404NotFound)
          .Produces(StatusCodes.Status500InternalServerError);
        }

        private static string GetContentType(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();
            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                _ => "application/octet-stream",
            };
        }
    }
}
