
namespace MySuperHeroApp.ApiService.Jobs.Core
{
    public class JobWorker : BackgroundService
    {
        private readonly ITaskQueue _taskQueue;
        private readonly ILogger<JobWorker> _logger;

        public JobWorker(ITaskQueue taskQueue, ILogger<JobWorker> logger)
        {
            _taskQueue = taskQueue;
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("JobWorker started.");
            while(!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    // Wait for a task to be available in the queue
                    var task = await _taskQueue.DeQueueAsync(stoppingToken);
                    if (task != null)
                    {
                        // Execute the task
                        await task(stoppingToken);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while processing the job.");
                }
            }
            _logger.LogInformation("JobWorker stopped.");           
        }
    }
}
