using InstaConnect.Common.Domain.Features.Common.Utilities;
using InstaConnect.Common.Domain.Features.Validations.Extensions;

using Microsoft.Extensions.Options;

namespace InstaConnect.Common.Domain.Features.Common.Helpers;

internal sealed class FluentValidationOptionsValidator<TOptions> : IValidateOptions<TOptions>
	where TOptions : class, IApplicationOptions
{
	private readonly string _sectionName;
	private readonly IEnumerable<IValidator<TOptions>> _validators;

	public FluentValidationOptionsValidator(string sectionName, IEnumerable<IValidator<TOptions>> validators)
	{
		_sectionName = sectionName;
		_validators = validators;
	}

	public ValidateOptionsResult Validate(string? name, TOptions options)
	{
		var errorMessages = _validators.GetErrorMessages(options);

		if (errorMessages.Any())
		{
			return ValidateOptionsResult.Fail(CommonOptionsErrorMessages.GetInvalid(_sectionName, errorMessages));
		}

		return ValidateOptionsResult.Success;
	}
}
