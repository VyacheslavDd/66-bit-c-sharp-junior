using FootballersCatalog.Domain.Enums;
using FootballersCatalogCore.Domain.Base.Models;

namespace FootballersCatalog.Domain.Entities
{
    public class Footballer : BaseEntity<Guid>
	{
		public required string Name { get; set; }
		public required string Surname { get; set; }
		public required Gender Gender { get; set; }
		public required DateTime BirthDate { get; set; }
		public required Guid TeamId { get; set; }
		public required Team Team { get; set; }
		public required Country Country { get; set; }
	}
}
