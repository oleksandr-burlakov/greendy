using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Greendy.BLL.Configuration
{
    public static class ServiceExtensions
    {
        public static void ConfigureMediatr(this IServiceCollection services) {
            services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        } 
    }
}