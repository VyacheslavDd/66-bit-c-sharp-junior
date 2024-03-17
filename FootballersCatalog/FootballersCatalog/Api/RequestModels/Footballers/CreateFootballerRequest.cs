using FootballersCatalog.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace FootballersCatalog.Api.RequestModels.Footballers
{
	public class CreateFootballerRequest
	{
		public required string Name { get; set; }
		public required string Surname { get; set; }
		public required Gender Gender { get; set; }
		public required DateTime BirthDate { get; set; }
		public required Country Country { get; set; }
		public required string TeamName { get; set; }
	}
}
