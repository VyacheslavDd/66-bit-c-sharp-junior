using FootballersCatalog.Domain.Entities;
using FootballersCatalog.Domain.Interfaces;
using FootballersCatalog.Infrastructure.Contexts;
using FootballersCatalogCore.Domain.Base.Repositories;

namespace FootballersCatalog.Infrastructure.Repositories
{
	internal class FootballerRepository : BaseRepository<Footballer>, IFootballerRepository
	{
		private readonly FootballersCatalogContext _footballerContext;

		public FootballerRepository(FootballersCatalogContext footballerContext) : base(footballerContext.Footballers, footballerContext)
		{
			_footballerContext = footballerContext;
		}
	}
}
