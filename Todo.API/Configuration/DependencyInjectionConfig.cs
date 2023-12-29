
using Todo.Business.Interfaces;
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

            return services;
        }
    }
}