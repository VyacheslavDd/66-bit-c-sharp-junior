using FootballersCatalog.Domain.Entities;
using FootballersCatalog.Domain.Interfaces;
using FootballersCatalog.Services.Interfaces;
using FootballersCatalogCore.Exceptions;
using FootballersCatalogCore.Services.Base.Implementations;

namespace FootballersCatalog.Services.Implementations
{
	internal class FootballerService : BaseService<Footballer>, IFootballerService
	{
		private readonly IFootballerRepository _footballerRepository;
		private readonly ITeamRepository _teamRepository;

		public FootballerService(IFootballerRepository footballerRepository, ITeamRepository teamService) : base(footballerRepository)
		{
			_footballerRepository = footballerRepository;
			_teamRepository = teamService;
		}

		public async override Task<Guid> AddAsync(Footballer footballer)
		{
			var team = await _teamRepository.FindTeamByNameAsync(footballer.Team.Name);
			if (team is null) ExceptionHandler.Throw(ExceptionType.NotExistingTeam, "Укажите существующую команду!");
			team.Footballers.Add(footballer);
			return await base.AddAsync(footballer);
		}

		public async override Task<Footballer> GetByGuidAsync(Guid guid)
		{
			var footballer = await _footballerRepository.GetByGuidAsync(guid);
			if (footballer is null) ExceptionHandler.Throw(ExceptionType.NotExistingFootballer, "Укажите существующего футболиста!");
			return footballer;
		}

		public async Task UpdateAsync(Footballer footballerModel)
		{
			var footballer = await GetByGuidAsync(footballerModel.Id);
			if (footballer is null) ExceptionHandler.Throw(ExceptionType.NotExistingFootballer, "Укажите существующего футболиста!");
			var team = await _teamRepository.FindTeamByNameAsync(footballerModel.Team.Name);
			if (team is null) ExceptionHandler.Throw(ExceptionType.NotExistingTeam, "Укажите существующую команду!");
			footballer.Name = footballerModel.Name;
			footballer.Surname = footballerModel.Surname;
			footballer.Gender = footballerModel.Gender;
			footballer.BirthDate = footballerModel.BirthDate;
			footballer.Country = footballerModel.Country;
			footballer.Team = team;
			await base.UpdateAsync();
		}
	}
}
