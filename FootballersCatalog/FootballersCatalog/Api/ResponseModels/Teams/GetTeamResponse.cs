using FootballersCatalog.Api.ResponseModels.Footballers;

namespace FootballersCatalog.Api.ResponseModels.Teams
{
	public class GetTeamResponse
	{
		public required string Name { get; set; }
		public required List<GetFootballerResponse> Footballers { get; set; }
	}
}
