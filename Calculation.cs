using System;
using System.Reflection;
using System.Threading;

namespace delegateTutorial
{
    public interface ICalCulation
    {
        (int Result, string MethodName) Add(int x, int y);
        (int Result, string MethodName) Sub(int x, int y);
        (int Result, string MethodName) Multip(int x, int y);
        (int Result, string MethodName) Divid(int x, int y);
    }

    public class Calculation : ICalCulation
    {
        public (int Result, string MethodName) Add(int x, int y) {
            var classType = this.GetType();
            if (Thread.CurrentThread.IsThreadPoolThread)
                Thread.CurrentThread.Name = $"{classType.Name} | AddMethod | Thread";

            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine($"{Thread.CurrentThread.Name}: Add executed {i} second(s).");
            }
            Console.WriteLine("Calculation | Add | complete!");
            return (x+y, "Add");
        }

        public (int Result, string MethodName) Sub(int x, int y) {
            var classType = this.GetType();
            if (Thread.CurrentThread.IsThreadPoolThread)
                Thread.CurrentThread.Name = $"{classType.Name} | SubMethod | Thread";

            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine($"{Thread.CurrentThread.Name}: Add executed {i} second(s).");
            }
            Console.WriteLine("Calculation | Sub | complete!");
            return (x - y, "Sub");
        }

        public (int Result, string MethodName) Multip(int x, int y) {
            var classType = this.GetType();
            if (Thread.CurrentThread.IsThreadPoolThread)
                Thread.CurrentThread.Name = $"{classType.Name} | MultipMethod | Thread";

            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine($"{Thread.CurrentThread.Name}: Add executed {i} second(s).");
            }
            Console.WriteLine("Calculation | Multip | complete!");
            return (x * y, "Multip");
        }

        public (int Result, string MethodName) Divid(int x, int y) {
            var classType = this.GetType();
            if (Thread.CurrentThread.IsThreadPoolThread)
                Thread.CurrentThread.Name = $"{classType.Name} | DividMethod | Thread";

            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine($"{Thread.CurrentThread.Name}: Add executed {i} second(s).");
            }
            Console.WriteLine("Calculation | Divid | complete!");
            return (y != 0 ? x / y : 0, "Divid");
        }
    }
}