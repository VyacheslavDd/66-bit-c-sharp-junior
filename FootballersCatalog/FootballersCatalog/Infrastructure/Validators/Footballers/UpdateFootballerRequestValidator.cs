using FluentValidation;
using FootballersCatalog.Api.RequestModels.Footballers;
using FootballersCatalogCore.Helpers;

namespace FootballersCatalog.Infrastructure.Validators.Footballers
{
	public class UpdateFootballerRequestValidator : AbstractValidator<UpdateFootballerRequest>
	{
		public UpdateFootballerRequestValidator()
		{
			RuleFor(f => f.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(30);
			RuleFor(f => f.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(30);
			RuleFor(f => f.Gender).IsInEnum();
			RuleFor(f => f.Country).IsInEnum();
			RuleFor(f => f.BirthDate).Must(DateHelper.BeEnoughTimeSpan);
			RuleFor(f => f.TeamName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(40);
		}
	}
}
