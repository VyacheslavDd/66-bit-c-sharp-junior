using FootballersCatalog.Domain.Enums;

namespace FootballersCatalog.Api.RequestModels.Footballers
{
	public class UpdateFootballerRequest
	{
		public required string Name { get; set; }
		public required string Surname { get; set; }
		public required Gender Gender { get; set; }
		public required DateTime BirthDate { get; set; }
		public required Country Country { get; set; }
		public required string TeamName { get; set; }
	}
}
