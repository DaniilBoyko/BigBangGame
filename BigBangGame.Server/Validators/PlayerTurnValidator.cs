using BigBangGame.Server.Models.Input;
using FluentValidation;

namespace BigBangGame.Server.Validators;

public class PlayerTurnValidator : AbstractValidator<PlayerTurn>
{
	public PlayerTurnValidator()
	{
		RuleFor(x => x.ChoiceId)
			.NotNull()
			.GreaterThanOrEqualTo(1)
			.LessThanOrEqualTo(5);
	}
}
