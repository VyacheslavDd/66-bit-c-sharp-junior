using FootballersCatalog.Domain.Entities;
using FootballersCatalog.Domain.Interfaces;
using FootballersCatalog.Services.Interfaces;
using FootballersCatalogCore.Domain.Base.Interfaces;
using FootballersCatalogCore.Exceptions;
using FootballersCatalogCore.Services.Base.Implementations;

namespace FootballersCatalog.Services.Implementations
{
	internal class TeamService : BaseService<Team>, ITeamService
	{
		private readonly ITeamRepository _teamRepository;

		public TeamService(ITeamRepository teamRepository) : base(teamRepository)
		{
			_teamRepository = teamRepository;
		}

		public async Task IsUnique(string name)
		{
			var teams = await GetAllAsync();
			if (teams.Any(t => t.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
				ExceptionHandler.Throw(ExceptionType.NotUniqueTeam, "Введите уникальное название команды!");
		}

		public async Task UpdateAsync(Guid id, Team team)
		{
			await IsUnique(team.Name);
			var entity = await GetByGuidAsync(id);
			if (entity is null) ExceptionHandler.Throw(ExceptionType.NotExistingTeam, "Команды с указанным Guid не существует!");
			entity.Name = team.Name;
			await base.UpdateAsync();
		}

		public override async Task<Team> GetByGuidAsync(Guid guid)
		{
			var team = await base.GetByGuidAsync(guid);
			if (team is null) ExceptionHandler.Throw(ExceptionType.NotExistingTeam, "Команды с указанным Guid не существует!");
			return team;
		}

		public override async Task<Guid> AddAsync(Team team)
		{
			await IsUnique(team.Name);
			return await base.AddAsync(team);
		}
	}
}
