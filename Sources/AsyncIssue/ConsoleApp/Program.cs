using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Common;

namespace ConsoleApp
{
    class Program
    {
        private static MyWorker myWorker;

        private static void Main(string[] args)
        {
            myWorker = new MyWorker();

            Task.Run(() => Execute());

            Console.ReadKey();
        }

        public static async Task Execute()
        {
            myWorker.Start();

            await FooAsync();

            await FooAsync();

            await FooAsync();

            await FooAsync();

            await myWorker.StopAsync();

            Debug.WriteLine("All Done. Thread ID: {0}", Environment.CurrentManagedThreadId);
        }

        private static async Task FooAsync()
        {
            Debug.WriteLine("FooAsync starting. Before calling Task.Delay. Thread ID: {0}", Environment.CurrentManagedThreadId);

            await Task.Delay(300);

            Debug.WriteLine("FooAsync is about to call myWorker.Jolt(). Thread ID: {0}", Environment.CurrentManagedThreadId);

            myWorker.Jolt();

            Debug.WriteLine("FooAsync completed. Thread ID: {0}", Environment.CurrentManagedThreadId);
        }
    }
}
