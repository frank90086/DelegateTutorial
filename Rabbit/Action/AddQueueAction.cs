namespace delegateTutorial
{
    public class AddQueueAction : BaseQueueAction
    {
        public AddQueueAction(IRabbitContext context) : base(context) { }
        public override void Do(RabbitOperationModel model)
        {
            _context.AddQueue(model.Value);
            base.Reply(model);
        }
    }
}