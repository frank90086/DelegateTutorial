using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Resolvers;

namespace delegateTutorial
{
    public interface IRabbitOperation
    {
        void Start();
    }
    public class RabbitOperation : IRabbitOperation
    {
        private readonly IRabbitContext _context;
        private readonly IRabbitFactory _factory;
        private List<IRabbitConsumer> _consumers = new List<IRabbitConsumer>();
        public RabbitOperation(IRabbitContext context, IRabbitFactory factory)
        {
            _factory = factory;
            _context = context;
            _context.SetChannel(CommonSetting.Queue_Name);
            CreatConsumer(CommonSetting.Queue_Name);
            MessagePackSerializer.SetDefaultResolver(ContractlessStandardResolver.Instance);
        }
        public void Start()
        {
            string input;
            do
            {
                input = Console.ReadLine();
                var model = SerializeModel(input);
                var job = ReflectionObject.GenericReflectionWithParm<BaseQueueAction>($"{model.Action.ToString()}QueueAction", new object[]{_context});
                job.Do(model);

            } while (input.Trim().ToLower() != "exit");
        }

        public void CreatConsumer(string channel)
        {
            var consumer = new RabbitConsumer(_factory);
            consumer.SetChannel(CommonSetting.Queue_Name);
            _consumers.Add(consumer);
        }

        private RabbitOperationModel SerializeModel(string input)
        {
            string[] msg = input.Split(':');
            if (msg.Length < 2) return CreateModel(input);

            if (msg.Length < 3) return CreateModel(EnumTransfer(msg[0]), msg[1]);

            return CreateModel(EnumTransfer(msg[0]), msg[1], msg[2]);
        }

        private ActionType EnumTransfer(string str)
        {
            if (Enum.IsDefined(typeof(ActionType), str))
                return (ActionType)Enum.Parse(typeof(ActionType), str);
            else
                return ActionType.None;
        }
        private RabbitOperationModel CreateModel(string msg) => CreateModel(ActionType.SendAll, null, msg);
        private RabbitOperationModel CreateModel(ActionType action, string value) => CreateModel(action, value, null);
        private RabbitOperationModel CreateModel(ActionType action, string value, string msg)
        {
            return new RabbitOperationModel() {
                Action = action,
                Value =value,
                Message = msg
            };
        }
    }
}