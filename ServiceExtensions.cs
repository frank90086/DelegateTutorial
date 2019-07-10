using Microsoft.Extensions.DependencyInjection;

namespace delegateTutorial
{
    public static class ServiceExtensions
    {
        private static readonly string Mq_User_Name = "admin";
        private static readonly string Mq_Password = "admin";
        private static readonly string Mq_Host_Name = "localhost";
        private static readonly int Mq_Port = 5672;
        public static IServiceCollection AddModuel(this IServiceCollection service)
        {
            service.AddSingleton<ICalCulation, Calculation>();
            service.AddSingleton<ICallBackEvent, CallBackEvent>();
            service.AddSingleton<IAsyncJob, AsyncJob>();
            service.AddSingleton<IRabbitFactory>(_ => new RabbitFactory(Mq_User_Name, Mq_Password, Mq_Host_Name, Mq_Port));
            service.AddSingleton<IRabbitContext, RabbitContext>();
            service.AddSingleton<IRabbitOperation, RabbitOperation>();
            return service;
        }
    }
}