namespace MySuperHeroApp.ApiService.Jobs.Core
{
    public interface ITaskQueue
    {
        Task<Func<CancellationToken, Task>> DeQueueAsync(CancellationToken token);
        void EnQueue(Func<CancellationToken, Task> task);
    }
}
