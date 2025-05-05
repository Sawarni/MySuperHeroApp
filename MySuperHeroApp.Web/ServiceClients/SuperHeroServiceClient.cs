using MySuperHeroApp.Web.Model;

namespace MySuperHeroApp.Web.ServiceClients
{
    public class SuperHeroServiceClient(HttpClient httpClient)
    {
        public string? ApiBaseUrl => httpClient.GetStringAsync(httpClient.BaseAddress).Result?.ToString();
        public async Task<SuperHero[]> GetSuperHeroesByPublisherAsync(string publisher,int page,int maxItems, CancellationToken cancellationToken = default)
        {
            List<SuperHero>? superHeroes = await httpClient.GetFromJsonAsync<List<SuperHero>>($"/api/{publisher}/superheroes/{page}/{maxItems}", cancellationToken);
            
            return superHeroes?.ToArray() ?? Array.Empty<SuperHero>();
        }

        public async Task<SuperHero[]> GetSuperHeroesByPublisherAsync(string publisher, CancellationToken cancellationToken = default)
        {
            List<SuperHero>? superHeroes = await httpClient.GetFromJsonAsync<List<SuperHero>>($"/api/{publisher}/superheroes", cancellationToken);

            return superHeroes?.ToArray() ?? Array.Empty<SuperHero>();
        }

        public async Task<SuperHero?> GetSuperHeroesByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            SuperHero? superHero = await httpClient.GetFromJsonAsync<SuperHero>($"/api/superheroes/{id}", cancellationToken);

            return superHero;
        }

        public async Task<List<string>?> GetPublishersAsync(CancellationToken cancellationToken = default)
        {
            var publishers = await httpClient.GetFromJsonAsync<List<string>>($"/api/superheroes/publishers", cancellationToken);

            return publishers?.Where(x=> !string.IsNullOrWhiteSpace(x)).ToList() ;
        }

        public  string GetPicture(string id, CancellationToken cancellationToken = default)
        {
            var pic = httpClient.GetByteArrayAsync($"/api/superheroes/image/{id}", cancellationToken).Result;
            var base64String = Convert.ToBase64String(pic);
            return $"data:image/jpeg;base64,{base64String}";
        }
    }

   
}
