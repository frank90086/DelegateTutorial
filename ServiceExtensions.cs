using Microsoft.Extensions.DependencyInjection;

namespace delegateTutorial
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddModuel(this IServiceCollection service)
        {
            service.AddSingleton<ICalCulation, Calculation>();
            service.AddSingleton<ICallBackEvent, CallBackEvent>();
            service.AddSingleton<IAsyncJob, AsyncJob>();
            return service;
        }
    }
}