namespace delegateTutorial
{
    public class SendAllQueueAction : BaseQueueAction
    {
        public SendAllQueueAction(IRabbitContext context) : base(context) { }

        public override void Do(RabbitOperationModel model) => _context.SendAll(model.Message);
    }
}