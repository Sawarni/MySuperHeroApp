using Microsoft.AspNetCore.Mvc;
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
            routes.AddGetAllSuperHeroesEndpoint()
                  .AddGetSuperHeroByIdEndpoint()
                  .AddSyncSuperHeroByIdEndpoint()
                  .AddSyncAllSuperHeroEndpoint()
                  .AddGetSuperHeroImageEndpoint()
                  .AddGetSuperHeroesByPublisherEndpoint()
                  .AddGetAllSuperHeroesByPublisherEndpoint();
        }

        private static IEndpointRouteBuilder AddGetSuperHeroImageEndpoint(this IEndpointRouteBuilder routes)
        {
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
            return routes;
        }

        private static IEndpointRouteBuilder AddSyncAllSuperHeroEndpoint(this IEndpointRouteBuilder routes)
        {
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
            return routes;
        }

        private static IEndpointRouteBuilder AddSyncSuperHeroByIdEndpoint(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/superheroes/sync/{id}", async (string id, IAddSuperHeroTask addSuperHeroTask) =>
            {
                await addSuperHeroTask.AddSupperHeroToDbTask(id.ToString(), CancellationToken.None);
                return Results.Accepted();
            })
            .WithName("AddSuperHeroById")
            .Produces<SuperHero>(StatusCodes.Status202Accepted);
            return routes;
        }

        private static IEndpointRouteBuilder AddGetSuperHeroByIdEndpoint(this IEndpointRouteBuilder routes)
        {
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
            return routes;
        }

        private static IEndpointRouteBuilder AddGetAllSuperHeroesEndpoint(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/superheroes", async (SuperHeroDbContext db) =>
            {
                return await db.SuperHeroes.ToListAsync();
            })
            .WithName("GetAllSuperHeroes")
            .Produces<List<SuperHero>>(StatusCodes.Status200OK);
            return routes;
        }

        private static IEndpointRouteBuilder AddGetSuperHeroesByPublisherEndpoint(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/{publisher}/superheroes/{page}/{limit}", async (string publisher,
    int page, int limit, [FromServices] SuperHeroDbContext db) =>
            {
                if (page < 1 || limit < 1)
                {
                    return Results.BadRequest("Page and limit must be greater than 0.");
                }

                var superheroes = await db.SuperHeroes
                    .Where(s => s.Biography.Publisher == publisher)
                    .OrderBy(s => s.Name)
                    .Skip((page - 1) * limit)
                    .Take(limit)
                    .ToListAsync();

                return Results.Ok(superheroes);
            })
            .WithName("GetPagedSuperHeroesByPublisher")
            .Produces<List<SuperHero>>(StatusCodes.Status200OK);
            return routes;
        }

        private static IEndpointRouteBuilder AddGetAllSuperHeroesByPublisherEndpoint(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/{publisher}/superheroes", async (string publisher,
       [FromServices] SuperHeroDbContext db) =>
            {
               

                var superheroes = await db.SuperHeroes
                    .Where(s => s.Biography.Publisher == publisher)
                    .OrderBy(s => s.Name)                    
                    .ToListAsync();

                return Results.Ok(superheroes);
            })
            .WithName("GetAllSuperHeroesByPublisher")
            .Produces<List<SuperHero>>(StatusCodes.Status200OK);
            return routes;
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
