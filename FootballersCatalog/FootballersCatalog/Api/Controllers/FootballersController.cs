using AutoMapper;
using FootballersCatalog.Api.RequestModels.Footballers;
using FootballersCatalog.Api.ResponseModels.Footballers;
using FootballersCatalog.Domain.Entities;
using FootballersCatalog.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballersCatalog.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class FootballersController : ControllerBase
	{
		private readonly IFootballerService _footballerService;
		private readonly IMapper _mapper;

		public FootballersController(IFootballerService footballerService, IMapper mapper)
		{
			_footballerService = footballerService;
			_mapper = mapper;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="footballerRequest">Дату указывать в формате гггг-мм-дд</param>
		/// <returns></returns>
		[HttpPost]
		[Route("create")]
		[ProducesResponseType(201)]
		public async Task<IActionResult> CreateAsync([FromBody] CreateFootballerRequest footballerRequest)
		{
			var footballer = _mapper.Map<Footballer>(footballerRequest);
			var guid = await _footballerService.AddAsync(footballer);
			return Ok(guid);
		}

		[HttpGet]
		[Route("all")]
		public async Task<IActionResult> GetAllAsync()
		{
			var footballers = await _footballerService.GetAllAsync();
			var mappedFootballers = _mapper.Map<List<GetFootballerResponse>>(footballers);
			return Ok(mappedFootballers);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
		{
			var footballer = await _footballerService.GetByGuidAsync(id);
			var mapped = _mapper.Map<GetFootballerResponse>(footballer);
			return Ok(mapped);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="footballerRequest">дату указывать в формате гггг-мм-дд</param>
		/// <returns></returns>
		[HttpPut]
		[Route("{id}/update")]
		public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateFootballerRequest footballerRequest)
		{
			var footballerModel = _mapper.Map<Footballer>(footballerRequest);
			footballerModel.Id = id;
			await _footballerService.UpdateAsync(footballerModel);
			return Ok();
		}

		[HttpDelete]
		[Route("{id}/delete")]
		public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
		{
			await _footballerService.DeleteAsync(id);
			return Ok();
		}
	}
}
