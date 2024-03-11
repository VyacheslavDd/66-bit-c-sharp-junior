using FluentValidation;
using FootballersCatalog.Api.RequestModels.Teams;

namespace FootballersCatalog.Infrastructure.Validators.Teams
{
	public class UpdateTeamRequestValidator : AbstractValidator<UpdateTeamRequest>
	{
		public UpdateTeamRequestValidator()
		{
			RuleFor(t => t.Name).NotNull().NotEmpty().MinimumLength(4).MaximumLength(25);
		}
	}
}
