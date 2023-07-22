using Greendy.Application.Repositories;
using Greendy.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Greendy.Persistance;
public static class DependencyInjectionConfiguration 
{
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<ITrackItemCategoryRepository, TrackItemCategoryRepository>();
        services.AddTransient<ITrackStorageRepository, TrackStorageRepository>();
        services.AddTransient<IUserRoleRepository, UserRoleRepository>();
        services.AddTransient<ITrackItemRepository, TrackItemRepository>();
    }
}
