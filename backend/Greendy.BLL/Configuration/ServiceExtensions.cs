using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR.Pipeline;

namespace Greendy.BLL.Configuration
{
    public static class ServiceExtensions
    {
        public static void ConfigureMediatr(this IServiceCollection services) {
            services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
			services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(ExceptionLoggingHandler<,,>));
        }
    }
}
