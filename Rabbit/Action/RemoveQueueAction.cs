namespace delegateTutorial
{
    public class RemoveQueueAction : BaseQueueAction
    {
        public RemoveQueueAction(IRabbitContext context) : base(context) { }

        public override void Do(RabbitOperationModel model)
        {
            _context.RemoveQueue(model.Value);
            base.Reply(model);
        }
    }
}