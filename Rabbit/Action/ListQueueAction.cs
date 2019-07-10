using System;

namespace delegateTutorial
{
    public class ListQueueAction : BaseQueueAction
    {
        public ListQueueAction(IRabbitContext context) : base(context) { }

        public override void Do(RabbitOperationModel model)
        {
            if (String.IsNullOrEmpty(model.Value)) _context.SendAll(_context.QueueList);
            else _context.SendDirection(_context.QueueList, model.Value);
        }
    }
}