using System;
using System.Diagnostics;
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
            CommonThreadJob();
            return (x+y, "Add");
        }

        public (int Result, string MethodName) Sub(int x, int y) {
            CommonThreadJob();
            return (x - y, "Sub");
        }

        public (int Result, string MethodName) Multip(int x, int y) {
            CommonThreadJob();
            return (x * y, "Multip");
        }

        public (int Result, string MethodName) Divid(int x, int y) {
            CommonThreadJob();
            return (y != 0 ? x / y : 0, "Divid");
        }

        private void CommonThreadJob()
        {
            var currentMethodName = new StackTrace().GetFrame(1).GetMethod().Name;
            var classType = this.GetType();
            if (Thread.CurrentThread.IsThreadPoolThread)
                Thread.CurrentThread.Name = $"{classType.Name} | {currentMethodName} | {Thread.CurrentThread.ManagedThreadId}";

            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine($"{Thread.CurrentThread.Name}: Add executed {i} second(s).");
            }

            Console.WriteLine($"Calculation | {currentMethodName} | complete!");
        }
    }
}