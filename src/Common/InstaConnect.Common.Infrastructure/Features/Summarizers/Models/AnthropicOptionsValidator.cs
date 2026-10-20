namespace InstaConnect.Common.Infrastructure.Features.Summarizers.Models;

public class AnthropicOptionsValidator : AbstractValidator<AnthropicOptions>
{
	public AnthropicOptionsValidator()
	{
		RuleFor(o => o.ApiKey)
			.NotEmptyWithMessage();

		RuleFor(o => o.Model)
			.NotEmptyWithMessage();
	}
}
