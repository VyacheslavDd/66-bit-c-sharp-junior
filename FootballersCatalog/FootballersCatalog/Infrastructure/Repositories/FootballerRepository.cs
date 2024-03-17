using FootballersCatalog.Domain.Entities;
using FootballersCatalog.Domain.Interfaces;
using FootballersCatalog.Infrastructure.Contexts;
using FootballersCatalogCore.Domain.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FootballersCatalog.Infrastructure.Repositories
{
	internal class FootballerRepository : BaseRepository<Footballer>, IFootballerRepository
	{
		private readonly FootballersCatalogContext _footballerContext;

		public FootballerRepository(FootballersCatalogContext footballerContext) : base(footballerContext.Footballers, footballerContext)
		{
			_footballerContext = footballerContext;
		}

		public override IQueryable<Footballer> GetAllAsync()
		{
			return _footballerContext.Footballers.Include(f => f.Team).AsQueryable();
		}

		public override async Task<Footballer> GetByGuidAsync(Guid guid)
		{
			return await _footballerContext.Footballers.Include(f => f.Team).FirstOrDefaultAsync(f => f.Id == guid);
		}
	}
}
