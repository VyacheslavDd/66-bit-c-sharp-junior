using FootballersCatalog.Domain.Entities;
using FootballersCatalog.Domain.Interfaces;
using FootballersCatalog.Infrastructure.Contexts;
using FootballersCatalogCore.Domain.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FootballersCatalog.Infrastructure.Repositories
{
	internal class TeamRepository : BaseRepository<Team>, ITeamRepository
	{
		private readonly FootballersCatalogContext _footballerContext;

		public TeamRepository(FootballersCatalogContext footballerContext) : base(footballerContext.Teams, footballerContext)
		{
			_footballerContext = footballerContext;
		}

		public async override Task<Team> GetByGuidAsync(Guid guid)
		{
			return await _footballerContext.Teams.Include(t => t.Footballers).FirstOrDefaultAsync(t => t.Id == guid);
		}
	}
}
