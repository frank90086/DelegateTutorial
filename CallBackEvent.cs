using System;

namespace delegateTutorial
{
    public interface ICallBackEvent
    {
        event CallBackHandler CallBack;
        void OnComplete(object result);
    }

    public delegate void CallBackHandler(IEventArgs arg);

    public class CallBackEvent : ICallBackEvent
    {
        public event CallBackHandler CallBack;
        public void OnComplete(object result)
        {
            CallBackEventArgs args = new CallBackEventArgs(result);
            if (CallBack != null)
                CallBack(args);
            Console.WriteLine($"End With OnComplete!");
        }
    }
}