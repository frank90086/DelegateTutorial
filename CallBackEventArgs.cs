using System;

namespace delegateTutorial
{
    public interface IEventArgs
    {
        object Obj{ get; }
        ResultModel Model{ get; }
    }

    public class CallBackEventArgs : EventArgs, IEventArgs
    {
        private object _obj;
        private ResultModel _model;
        public CallBackEventArgs(object obj)
        {
            _obj = obj;
            _model = obj as ResultModel;
        }

        public Object Obj
        {
            get => _obj;
            private set {}
        }

        public ResultModel Model
        {
            get => _model;
            private set {}
        }
    }
}