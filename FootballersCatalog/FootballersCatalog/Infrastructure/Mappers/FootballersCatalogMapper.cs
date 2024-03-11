using AutoMapper;
using FootballersCatalog.Api.RequestModels.Teams;
using FootballersCatalog.Api.ResponseModels.Footballers;
using FootballersCatalog.Api.ResponseModels.Teams;
using FootballersCatalog.Domain.Entities;

namespace FootballersCatalog.Infrastructure.Mappers
{
	public class FootballersCatalogMapper : Profile
	{
		public FootballersCatalogMapper()
		{
			CreateMap<Team, GetTeamResponse>();
			CreateMap<Footballer, GetFootballerResponse>()
				.ForMember(gfr => gfr.Team, opt => opt.MapFrom(f => f.Team.Name));
			CreateMap<CreateTeamRequest, Team>();
			CreateMap<UpdateTeamRequest, Team>();
		}
	}
}
