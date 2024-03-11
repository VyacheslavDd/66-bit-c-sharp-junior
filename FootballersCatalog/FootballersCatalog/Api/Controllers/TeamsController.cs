using AutoMapper;
using FootballersCatalog.Api.RequestModels.Teams;
using FootballersCatalog.Api.ResponseModels.Footballers;
using FootballersCatalog.Api.ResponseModels.Teams;
using FootballersCatalog.Domain.Entities;
using FootballersCatalog.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballersCatalog.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class TeamsController : ControllerBase
	{
		private readonly ITeamService _teamService;
		private readonly IMapper _mapper;

		public TeamsController(ITeamService teamService, IMapper mapper)
		{
			_teamService = teamService;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("all")]
		public async Task<IActionResult> GetAllAsync()
		{
			var teams = await _teamService.GetAllAsync();
			var mappedTeams = _mapper.Map<List<GetTeamResponse>>(teams);
			return Ok(mappedTeams);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
		{
			var team = await _teamService.GetByGuidAsync(id);
			var mappedTeam = _mapper.Map<GetTeamResponse>(team);
			mappedTeam.Footballers = _mapper.Map<List<GetFootballerResponse>>(team.Footballers);
			return Ok(mappedTeam);
		}

		[HttpPost]
		[Route("create")]
		[ProducesResponseType(201)]
		public async Task<IActionResult> CreateAsync([FromBody] CreateTeamRequest createTeamRequest)
		{
			var entity = _mapper.Map<Team>(createTeamRequest);
			var guid = await _teamService.AddAsync(entity);
			return Ok(guid);
		}

		[HttpPut]
		[Route("{id}/update")]
		public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateTeamRequest updateTeamRequest)
		{
			var entity = _mapper.Map<Team>(updateTeamRequest);
			await _teamService.UpdateAsync(id, entity);
			return Ok();
		}

		[HttpDelete]
		[Route("{id}/delete")]
		public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
		{
			await _teamService.DeleteAsync(id);
			return Ok();
		}

	}
}
