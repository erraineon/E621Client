using System;
using System.Threading;
using System.Threading.Tasks;

namespace E621
{
    public class RateLimiter : IDisposable
    {
        private readonly SemaphoreSlim _semaphore;
        private readonly TimeSpan _time;

        public RateLimiter(int rate, TimeSpan time)
        {
            _time = time;
            _semaphore = new SemaphoreSlim(rate, rate);
        }

        public void Dispose()
        {
            _semaphore.Dispose();
        }

        public async Task WaitToProceed()
        {
            await _semaphore.WaitAsync();
            var releaseTask = ReleaseSemaphoreAfterDelay();
        }

        private async Task ReleaseSemaphoreAfterDelay()
        {
            await Task.Delay(_time);
            _semaphore.Release();
        }
    }
}