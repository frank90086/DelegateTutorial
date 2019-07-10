namespace delegateTutorial
{
    public abstract class BaseQueueAction : IQueueAction
    {
        protected IRabbitContext _context;
        public BaseQueueAction(IRabbitContext context)
        {
            _context = context;
        }

        public abstract void Do(RabbitOperationModel model);
        protected void Reply(RabbitOperationModel model) => _context.SendAll($"Queue {model.Action} {model.Value} Setting Complete!");
    }
}