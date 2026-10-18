using FluentValidation;

using InstaConnect.Common.Domain.Features.Validations.Extensions;

namespace InstaConnect.Common.Infrastructure.Features.Analyzers.Models;

public class OpenAiOptionsValidator : AbstractValidator<OpenAiOptions>
{
	public OpenAiOptionsValidator()
	{
		RuleFor(o => o.ApiKey)
			.NotEmptyWithMessage();

		RuleFor(o => o.Model)
			.NotEmptyWithMessage();
	}
}
