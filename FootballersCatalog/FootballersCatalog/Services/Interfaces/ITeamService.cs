using FootballersCatalog.Domain.Entities;
using FootballersCatalogCore.Services.Base.Implementations;
using FootballersCatalogCore.Services.Base.Interfaces;

namespace FootballersCatalog.Services.Interfaces
{
	public interface ITeamService : IService<Team>
	{
		Task UpdateAsync(Guid id, Team team);
		Task IsUnique(string name);
	}
}
