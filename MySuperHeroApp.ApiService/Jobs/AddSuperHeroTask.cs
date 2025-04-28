using System.Text.Json;
using MySuperHeroApp.ApiService.Database;
using MySuperHeroApp.ApiService.Jobs.Core;
using MySuperHeroApp.ApiService.Model;

namespace MySuperHeroApp.ApiService.Workers
{
    public class AddSuperHeroTask : IAddSuperHeroTask
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<AddSuperHeroTask> _logger;
        private readonly IConfiguration _configuration;
        private readonly ITaskQueue _taskQueue;

        public AddSuperHeroTask(IServiceScopeFactory serviceScopeFactory, ILogger<AddSuperHeroTask> logger, IConfiguration configuration, ITaskQueue taskQueue)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
            _configuration = configuration;
            _taskQueue = taskQueue;

        }

        public Task AddSupperHeroToDbTask(string heroId, CancellationToken stoppingToken)
        {
            string accessToken = _configuration.GetValue<string>("SuperHeroApiKey") ?? string.Empty;
            string baseUrl = _configuration.GetValue<string>("SuperHeroApiBaseUrl") ?? @"https://superheroapi.com/api";
            _taskQueue.EnQueue(async token =>
            {
                string apiUrl = $"{baseUrl}/{accessToken}/{heroId}";
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    _logger.LogInformation($"Fetching data from API: {apiUrl}");
                    var httpClientFactory = scope.ServiceProvider.GetRequiredService<IHttpClientFactory>();
                    var httpClient = httpClientFactory.CreateClient();
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl, stoppingToken);

                    if (response.IsSuccessStatusCode)
                    {
                        var options = new JsonSerializerOptions
                        {
                            Converters = { new NullStringConverter() }
                        };

                        string responseData = await response.Content.ReadAsStringAsync(stoppingToken);
                        var superHero = JsonSerializer.Deserialize<SuperHero>(responseData, options);

                        if (superHero != null)
                        {
                            // Save to database
                            try
                            {
                                var imageByte = await httpClient.GetByteArrayAsync(superHero.Image.Url, stoppingToken);
                                if (imageByte is null || imageByte.Length == 0)
                                {
                                    superHero.Image.Url = null;
                                }
                                else
                                {
                                    // code to save image to image folder
                                    var imageFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,  "images");

                                    // Ensure the directory exists
                                    if (!Directory.Exists(imageFolderPath))
                                    {
                                        Directory.CreateDirectory(imageFolderPath);
                                    }

                                    // Create the full path for the image
                                    var imagePath = Path.Combine(imageFolderPath, $"{superHero.Id}.jpg");

                                    // Write the image bytes to the file
                                    await File.WriteAllBytesAsync(imagePath, imageByte, stoppingToken);
                                }
                                
                            }
                            catch (Exception e)
                            {
                                _logger.LogError(e, "Error fetching image for SuperHero {Name}", superHero.Name);
                               
                            }


                            var dbContext = scope.ServiceProvider.GetRequiredService<SuperHeroDbContext>();
                            dbContext.SuperHeroes.Add(superHero);
                            await dbContext.SaveChangesAsync(stoppingToken);

                            _logger.LogInformation($"SuperHero {superHero.Name} saved to database.");

                        }
                    }
                    else
                    {
                        _logger.LogWarning($"API call failed with status code: {response.StatusCode}");
                    }
                }
            });

            return Task.CompletedTask;
        }


    }
}
