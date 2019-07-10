namespace delegateTutorial
{
    public class SendDirectionQueueAction : BaseQueueAction
    {
        public SendDirectionQueueAction(IRabbitContext context) : base(context) { }

        public override void Do(RabbitOperationModel model) => _context.SendDirection(model.Message, model.Value);
    }
}