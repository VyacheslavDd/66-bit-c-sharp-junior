using FootballersCatalogCore.Domain.Base.Interfaces;
using FootballersCatalogCore.Services.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballersCatalogCore.Services.Base.Implementations
{
	public abstract class BaseService<T> : IService<T> where T : class
	{
		protected readonly IRepository<T> _repository;

		public BaseService(IRepository<T> repository)
		{
			_repository = repository;
		}

		public virtual async Task<Guid> AddAsync(T entity)
		{
			var guid = await _repository.AddAsync(entity);
			return guid;
		}

		public virtual async Task DeleteAsync(Guid guid)
		{
			await _repository.DeleteAsync(guid);
		}

		public virtual async Task<List<T>> GetAllAsync()
		{
			return await (await _repository.GetAllAsync()).ToListAsync();
		}

		public virtual async Task<T> GetByGuidAsync(Guid guid)
		{
			return await _repository.GetByGuidAsync(guid);
		}

		public virtual async Task UpdateAsync()
		{
			await _repository.UpdateAsync();
		}
	}
}
