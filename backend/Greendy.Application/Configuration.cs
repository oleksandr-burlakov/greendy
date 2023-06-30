namespace Greendy.Application;

using Greendy.Application.Interfaces;
using Greendy.Application.Services;
using Microsoft.Extensions.DependencyInjection;
public static class DependencyInjectionConfiguration 
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<ITrackItemCategoryService, TrackItemCategoryService>();
        services.AddTransient<ITrackStorageService, TrackStorageService>();
    }
}
