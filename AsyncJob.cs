using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace delegateTutorial
{
    public interface IAsyncJob
    {
        IEnumerable<Task> Do();
    }

    public delegate  (int Result, string MethodName) DelegateJob(int x, int y);

    public class AsyncJob : IAsyncJob
    {
        private readonly ICalCulation _cal;
        private readonly ICallBackEvent _callBack;
        public AsyncJob(ICalCulation cal, ICallBackEvent callBack)
        {
            _cal = cal;
            _callBack = callBack;
        }

        public IEnumerable<Task> Do()
        {
            DelegateJob del = _cal.Add;
            del += _cal.Sub;
            del += _cal.Multip;
            del += _cal.Divid;
            _callBack.CallBack += Print;

            foreach (var d in del.GetInvocationList())
            {
                Task task = Task.Run(()=>{
                    Random rm = new Random();
                    return (d as DelegateJob)(rm.Next(1, 100), rm.Next(1, 100));
                }).ContinueWith(back => {
                    var (result, methodName) = back.Result;
                    _callBack.OnComplete(new { Result = result, MethodName = methodName});
                });
                yield return task;
            }
        }

        private void Print(IEventArgs arg)
        {
            if (arg.Model != null)
                Console.WriteLine($"{arg.Model.MethodName} Result : {arg.Model.Result}!");
            else
                Console.WriteLine($"The Result : {arg.Obj.ToString()}!");
        }
    }
}