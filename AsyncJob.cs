using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace delegateTutorial
{
    public interface IAsyncJob
    {
        IEnumerable<Task> Do();
    }

    public delegate int DelegateJob(int x, int y);

    public class AsyncJob : IAsyncJob
    {
        private readonly ICalCulation _cal;
        private readonly ICallBackEvent _callBack;
        public List<Task> List = new List<Task>();
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
                    return d.DynamicInvoke(2, 5);
                }).ContinueWith(result => _callBack.OnComplete(result.Result));
                // List.Add(task);
                yield return task;
            }
            // return List;
        }

        private void Print(IEventArgs arg) => Console.WriteLine(arg.Value?.ToString());
    }
}