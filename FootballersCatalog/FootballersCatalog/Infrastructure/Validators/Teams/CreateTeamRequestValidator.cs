using FluentValidation;
using FootballersCatalog.Api.RequestModels.Teams;

namespace FootballersCatalog.Infrastructure.Validators.Teams
{
	public class CreateTeamRequestValidator : AbstractValidator<CreateTeamRequest>
	{
		public CreateTeamRequestValidator() 
		{
			RuleFor(t => t.Name).NotNull().NotEmpty().MinimumLength(4).MaximumLength(25);
		}
	}
}
