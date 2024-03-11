
using FootballersCatalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballersCatalog.Infrastructure.Contexts
{
	public class FootballersCatalogContext : DbContext
	{
		public DbSet<Footballer> Footballers { get; set; }
		public DbSet<Team> Teams { get; set; }

		public FootballersCatalogContext(DbContextOptions<FootballersCatalogContext> options) : base(options)
		{
			Database.Migrate();
		}
	}
}
