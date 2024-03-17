using FootballersCatalog.Domain.Entities;
using FootballersCatalogCore.Domain.Base.Interfaces;

namespace FootballersCatalog.Domain.Interfaces
{
	public interface ITeamRepository : IRepository<Team>
	{
		Task<Team> FindTeamByNameAsync(string name);
	}
}
