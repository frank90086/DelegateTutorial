using System;
using System.Reflection;
using System.Threading;

namespace delegateTutorial
{
    public interface ICalCulation
    {
        int Add(int x, int y);
        int Sub(int x, int y);
        int Multip(int x, int y);
        int Divid(int x, int y);
    }

    public class Calculation : ICalCulation
    {
        public int Add(int x, int y) {
            var classType = this.GetType();
            if (Thread.CurrentThread.IsThreadPoolThread)
                Thread.CurrentThread.Name = $"{classType.Name} | AddMethod | Thread";

            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine($"{Thread.CurrentThread.Name}: Add executed {i} second(s).");
            }
            Console.WriteLine("Calculation complete!");
            return x + y;
        }

        public int Sub(int x, int y) {
            var classType = this.GetType();
            if (Thread.CurrentThread.IsThreadPoolThread)
                Thread.CurrentThread.Name = $"{classType.Name} | SubMethod | Thread";

            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine($"{Thread.CurrentThread.Name}: Add executed {i} second(s).");
            }
            Console.WriteLine("Calculation complete!");
            return x - y;
        }

        public int Multip(int x, int y) {
            var classType = this.GetType();
            if (Thread.CurrentThread.IsThreadPoolThread)
                Thread.CurrentThread.Name = $"{classType.Name} | MultipMethod | Thread";

            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine($"{Thread.CurrentThread.Name}: Add executed {i} second(s).");
            }
            Console.WriteLine("Calculation complete!");
            return x * y;
        }

        public int Divid(int x, int y) {
            var classType = this.GetType();
            if (Thread.CurrentThread.IsThreadPoolThread)
                Thread.CurrentThread.Name = $"{classType.Name} | DividMethod | Thread";

            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine($"{Thread.CurrentThread.Name}: Add executed {i} second(s).");
            }
            Console.WriteLine("Calculation complete!");
            return y != 0 ? x / y : 0;
        }
    }
}