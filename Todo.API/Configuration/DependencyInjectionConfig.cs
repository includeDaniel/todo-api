
using Todo.Business.Interfaces;
using Todo.Business.Interfaces.Services;
using Todo.Business.Services;
using Todo.Business.Notifications;
using Todo.Infrastructure;
using Todo.Infrastructure.Repository;


namespace ApiRestful.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // context

            services.AddScoped<TodoContext>();


            // repository

            services.AddScoped<ITodoRepository, TodoRepository>();

            //service

            services.AddScoped<ITodoService, TodoService>();

            //Notify
            services.AddScoped<INotify, Notifier>();

            return services;
        }
    }
}