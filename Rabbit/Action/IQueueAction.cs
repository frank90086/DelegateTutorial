namespace delegateTutorial
{
    public interface IQueueAction
    {
        void Do(RabbitOperationModel model);
    }
}