using System;

namespace delegateTutorial
{
    public interface IEventArgs
    {
        object Value{ get; set; }
    }

    public class CallBackEventArgs : EventArgs, IEventArgs
    {
        private object _obj;
        public CallBackEventArgs(object obj)
        {
            _obj = obj;
        }

        public Object Value
        {
            get => _obj;
            set => _obj = value;
        }
    }
}