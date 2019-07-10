namespace delegateTutorial
{
    public class NoneQueueAction : BaseQueueAction
    {
        public NoneQueueAction(IRabbitContext context) : base(context) { }

        public override void Do(RabbitOperationModel model) => _context.SendAll("指令錯誤");
    }
}