using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace delegateTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            //DI Model
            var service = new ServiceCollection().AddModuel().BuildServiceProvider();

            //Get DI Instances
            var cal = service.GetRequiredService<ICalCulation>();
            var callBack = service.GetRequiredService<ICallBackEvent>();
            var asyncJob = service.GetRequiredService<IAsyncJob>();
            var tasks = new List<Task>();

            Console.WriteLine("Client application started!");
            Thread.CurrentThread.Name = "Main | Thread";

            foreach (var t in asyncJob.Do())
                tasks.Add(t);

            for (int i = 1; i <= 3; i++) {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine($"{Thread.CurrentThread.Name}: Client executed {i} second(s).");
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
