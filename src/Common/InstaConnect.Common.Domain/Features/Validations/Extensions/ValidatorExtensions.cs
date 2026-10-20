using FluentValidation.Results;

namespace InstaConnect.Common.Domain.Features.Validations.Extensions;

public static class ValidatorExtensions
{
	extension<T>(IEnumerable<IValidator<T>> validators)
	{
		public IReadOnlyCollection<string> GetErrorMessages(T instance)
		{
			var validationContext = new ValidationContext<T>(instance);

			var validationResults = validators.Select(v => v.Validate(validationContext));

			return ToErrorMessages(validationResults);
		}

		public async Task<IReadOnlyCollection<string>> GetErrorMessagesAsync(T instance, CancellationToken cancellationToken)
		{
			var validationContext = new ValidationContext<T>(instance);

			var validationResults = await Task.WhenAll(
				validators.Select(v => v.ValidateAsync(validationContext, cancellationToken)));

			return validationResults.ToErrorMessages();
		}
	}

	extension(IEnumerable<ValidationResult> validationResults)
	{
		public IReadOnlyCollection<string> ToErrorMessages()
		{
			return [.. validationResults
				.SelectMany(vr => vr.Errors)
				.Select(vf => vf.ErrorMessage)];
		}
	}
}
