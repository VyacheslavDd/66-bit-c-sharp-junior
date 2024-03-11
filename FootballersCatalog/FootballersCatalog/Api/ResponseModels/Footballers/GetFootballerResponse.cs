using FootballersCatalog.Domain.Enums;

namespace FootballersCatalog.Api.ResponseModels.Footballers
{
	public class GetFootballerResponse
	{
		public required string Name { get; set; }
		public required string Surname { get; set; }
		public required Gender Gender { get; set; }
		public required DateTime BirthDate { get; set; }
		public required string Team { get; set; }
		public required Country Country { get; set; }
	}
}
