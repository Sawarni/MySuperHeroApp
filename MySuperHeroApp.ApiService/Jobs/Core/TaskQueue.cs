using System.Collections.Concurrent;

namespace MySuperHeroApp.ApiService.Jobs.Core
{
    public class TaskQueue : ITaskQueue
    {
        private readonly ConcurrentQueue<Func<CancellationToken, Task>> _queue = new();
        private readonly SemaphoreSlim _signal = new(0);

        public void EnQueue(Func<CancellationToken, Task> task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));

            _queue.Enqueue(task);
            _signal.Release();
        }

        public async Task<Func<CancellationToken, Task>> DeQueueAsync(CancellationToken token)
        {
            await _signal.WaitAsync(token);
            _queue.TryDequeue(out var task);
            if (task == null)
            {
                throw new InvalidOperationException("No task available in the queue.");
            }
            return task;
        }
    }
}
