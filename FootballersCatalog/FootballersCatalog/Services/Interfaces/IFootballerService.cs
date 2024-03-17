using FootballersCatalog.Domain.Entities;
using FootballersCatalogCore.Services.Base.Interfaces;

namespace FootballersCatalog.Services.Interfaces
{
	public interface IFootballerService : IService<Footballer>
	{
		Task UpdateAsync(Footballer footballer);
	}
}
