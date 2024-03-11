using FootballersCatalog.Services.Implementations;
using FootballersCatalog.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FootballersCatalog.Infrastructure.Startups
{
	public static class ServicesStartup
	{
		public static IServiceCollection TryAddServices(this IServiceCollection services)
		{
			services.TryAddScoped<IFootballerService, FootballerService>();
			services.TryAddScoped<ITeamService, TeamService>();
			return services;
		}
	}
}
