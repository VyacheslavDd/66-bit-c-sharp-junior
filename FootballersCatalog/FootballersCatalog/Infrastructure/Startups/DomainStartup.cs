using FootballersCatalog.Domain.Interfaces;
using FootballersCatalog.Infrastructure.Contexts;
using FootballersCatalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FootballersCatalog.Infrastructure.Startups
{
	public static class DomainStartup
	{
		public static IServiceCollection TryAddDomain(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<FootballersCatalogContext>(opt => opt.UseNpgsql(config.GetConnectionString("PostgresDb")));
			services.TryAddScoped<IFootballerRepository, FootballerRepository>();
			services.TryAddScoped<ITeamRepository, TeamRepository>();
			return services;
		}
	}
}
