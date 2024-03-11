using FootballersCatalogCore.Domain.Base.Models;

namespace FootballersCatalog.Domain.Entities
{
    public class Team : BaseEntity<Guid>
	{
		public required string Name { get; set; }
		public required List<Footballer> Footballers { get; set; }
	}
}
