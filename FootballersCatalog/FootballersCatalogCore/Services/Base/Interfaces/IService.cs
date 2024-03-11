using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballersCatalogCore.Services.Base.Interfaces
{
	public interface IService<T>
	{
		Task<List<T>> GetAllAsync();
		Task<T> GetByGuidAsync(Guid guid);
		Task<Guid> AddAsync(T entity);
		Task UpdateAsync();
		Task DeleteAsync(Guid guid);
	}
}
