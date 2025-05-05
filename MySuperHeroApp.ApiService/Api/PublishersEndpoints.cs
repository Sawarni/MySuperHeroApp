using Microsoft.EntityFrameworkCore;
using MySuperHeroApp.ApiService.Database;
using MySuperHeroApp.ApiService.Model;
using MySuperHeroApp.ApiService.Workers;

namespace MySuperHeroApp.ApiService.Api
{
    public static class PublishersEndpoints
    {
        public static void MapPublisherEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.AddGetAllPublishersEndpoint();

        }

        private static IEndpointRouteBuilder AddGetAllPublishersEndpoint(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/superheroes/publishers", async (SuperHeroDbContext db) =>
            {
                //Return an order list where publisher with most number of items first. Write it


                var publishers = await db.SuperHeroes.Where(x => x.Biography.Publisher != null) // Filter out superheroes without a publisher
                                                     .GroupBy(x => x.Biography.Publisher) // Group superheroes by publisher
                                                    .Select(group => new
                                                                    {
                                                                       Publisher = group.Key, // Publisher name
                                                                       Count = group.Count()  // Number of superheroes in this publisher
                                                                     }
                                                    )
                                                    .OrderByDescending(p => p.Count).Select(x=> x.Publisher) // Order by count in descending order
                                                    .ToListAsync(); 
                return Results.Ok(publishers);
            })
                      .WithName("GetSuperHeroPublisher")
                      .Produces<SuperHero>(StatusCodes.Status200OK)
                      .Produces(StatusCodes.Status404NotFound)
                      .Produces(StatusCodes.Status500InternalServerError);
            return routes;
        }


    }
}
