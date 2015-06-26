using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// A class that runs some work on the ThreadPool.
    /// </summary>
    public class MyWorker
    {
        private Task workerWorkerTask;

        /// <summary>
        /// False before the background work starts and after it is stopped.
        /// True while the background work is in progress.
        /// </summary>
        private bool inProgress;

        /// <summary>
        /// If you need to use _cancellationTokenSource.Token then call GetCurrentCancellationToken.
        /// </summary>
        private CancellationTokenSource cancellationTokenSource;

        /// <summary>
        /// Offers protection when accessing from different threads.the cancellation token source.
        /// </summary>
        private readonly object lockObject;

        public MyWorker()
        {
            lockObject = new object();
            cancellationTokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            inProgress = true;
            workerWorkerTask = Task.Run(async () => await DoBackgroundWork());
        }

        /// <summary>
        /// Stops the worker and returns a task that can be awaited until the worker actually stopped.
        /// </summary>
        public Task StopAsync()
        {
            inProgress = false;
            CancelCurrentWorkerLoop();

            return workerWorkerTask;
        }

        /// <summary>
        /// Call this method to force the background loop to cancel any wait that may be in progress.
        /// This will force it to execute its workload immediately.
        /// </summary>
        public void Jolt()
        {
            CancelCurrentWorkerLoop();
        }

        private CancellationToken GetCurrentCancellationToken()
        {
            lock (lockObject)
            {
                return cancellationTokenSource.Token;
            }
        }

        private void CancelCurrentWorkerLoop()
        {
            lock (lockObject)
            {
                Debug.WriteLine("The current worker loop is being cancelled. We are just about to call cancellationTokenSource.Cancel(). Thread: {0}", Environment.CurrentManagedThreadId);
                
                cancellationTokenSource.Cancel();
                cancellationTokenSource = new CancellationTokenSource();

                Debug.WriteLine("The current worker loop was cancelled. Thread: {0}", Environment.CurrentManagedThreadId);
            }
        }

        /// <summary>
        /// The method that runs some work on the background thread.
        /// It consists from a loop. Each loop has a wait of one second and then a call to DoWork.
        /// Client code may call the method Jolt to cancel any wait currently in progress and in 
        /// this way force DoWork to be called sooner.
        /// </summary>
        /// <returns></returns>
        private async Task DoBackgroundWork()
        {
            try
            {
                Debug.WriteLine("The worker loop is starting. SynchronizationContext == null: {0}", SynchronizationContext.Current == null);

                while (inProgress)
                {
                    Debug.WriteLine("=========================================================");
                    Debug.WriteLine("Loop step 1. Starting the loop. Thread: {0}", Environment.CurrentManagedThreadId);

                    CancellationToken cancellationToken = GetCurrentCancellationToken();

                    try
                    {
                        Debug.WriteLine("Loop step 2. Before Task.Delay. Thread: {0}", Environment.CurrentManagedThreadId);
                        await Task.Delay(3000, cancellationToken);
                        Debug.WriteLine("Loop step 3. After Task.Delay. Thread: {0}", Environment.CurrentManagedThreadId);
                    }
                    catch (OperationCanceledException)
                    {
                        Debug.WriteLine("Wait interrupted. Thread: {0}", Environment.CurrentManagedThreadId);
                    }

                    DoWork();

                    Debug.WriteLine("Loop step 4. Ending the loop. Thread: {0}", Environment.CurrentManagedThreadId);
                }

                Debug.WriteLine("The worker loop is stopping.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("The worker loop encountered a fatal error. Error: {0}", ex.ToString());
                throw;
            }
        }

        private void DoWork()
        {
            // This is where the work is actually done
            Debug.WriteLine("Doing some actual work. Thread: {0}", Environment.CurrentManagedThreadId);
        }
    }
}
