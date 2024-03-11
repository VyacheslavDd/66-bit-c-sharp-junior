using FootballersCatalog.Domain.Entities;
using FootballersCatalog.Domain.Interfaces;
using FootballersCatalog.Services.Interfaces;
using FootballersCatalogCore.Services.Base.Implementations;

namespace FootballersCatalog.Services.Implementations
{
	internal class FootballerService : BaseService<Footballer>, IFootballerService
	{
		private readonly IFootballerRepository _footballerRepository;

		public FootballerService(IFootballerRepository footballerRepository) : base(footballerRepository)
		{
			_footballerRepository = footballerRepository;
		}
	}
}
