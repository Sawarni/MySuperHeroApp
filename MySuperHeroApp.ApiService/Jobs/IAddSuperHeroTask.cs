
namespace MySuperHeroApp.ApiService.Workers
{
    public interface IAddSuperHeroTask
    {
        Task AddSupperHeroToDbTask(string heroId, CancellationToken stoppingToken);
    }
}