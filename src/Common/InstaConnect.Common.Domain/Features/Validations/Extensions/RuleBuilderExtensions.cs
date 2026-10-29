using System.Linq.Expressions;

using InstaConnect.Common.Domain.Features.Validations.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Domain.Features.Validations.Extensions;

public static class RuleBuilderExtensions
{
	private const string PropertyNamePlaceholder = "{PropertyName}";

	extension<T, TProperty>(IRuleBuilder<T, TProperty> ruleBuilder)
	{
		public IRuleBuilderOptions<T, TProperty> NotEmptyWithMessage()
		{
			return ruleBuilder
				.NotEmpty()
				.WithMessage(CommonValidationErrorMessages.GetEmpty(PropertyNamePlaceholder));
		}

		public IRuleBuilderOptions<T, TProperty> EqualWithMessage(Expression<Func<T, TProperty>> equalPropertyExpression)
		{
			return ruleBuilder
				.Equal(equalPropertyExpression)
				.WithMessage(CommonValidationErrorMessages.GetNotEqual(PropertyNamePlaceholder, equalPropertyExpression.GetPropertyDisplayName()));
		}
	}

	extension<T>(IRuleBuilder<T, string> ruleBuilder)
	{
		public IRuleBuilderOptions<T, string> MinLengthWithMessage(int minLength)
		{
			return ruleBuilder
				.MinimumLength(minLength)
				.WithMessage((_, typeProperty) => CommonValidationErrorMessages.GetMinLength(PropertyNamePlaceholder, typeProperty.Length, minLength));
		}

		public IRuleBuilderOptions<T, string> MaxLengthWithMessage(int maxLength)
		{
			return ruleBuilder
				.MaximumLength(maxLength)
				.WithMessage((_, typeProperty) => CommonValidationErrorMessages.GetMaxLength(PropertyNamePlaceholder, typeProperty.Length, maxLength));
		}

		public IRuleBuilderOptions<T, string> InvalidEmailWithMessage()
		{
			return ruleBuilder
				.EmailAddress()
				.WithMessage(CommonValidationErrorMessages.GetInvalidEmail(PropertyNamePlaceholder));
		}
	}

	extension<T>(IRuleBuilder<T, int> ruleBuilder)
	{
		public IRuleBuilderOptions<T, int> MinValueWithMessage(int minValue)
		{
			return ruleBuilder
				.GreaterThanOrEqualTo(minValue)
				.WithMessage((_, typeProperty) => CommonValidationErrorMessages.GetMinValue(PropertyNamePlaceholder, typeProperty, minValue));
		}

		public IRuleBuilderOptions<T, int> MaxValueWithMessage(int maxValue)
		{
			return ruleBuilder
				.LessThanOrEqualTo(maxValue)
				.WithMessage((_, typeProperty) => CommonValidationErrorMessages.GetMaxValue(PropertyNamePlaceholder, typeProperty, maxValue));
		}
	}

	extension<T>(IRuleBuilder<T, IFormFile?> ruleBuilder)
	{
		public IRuleBuilderOptions<T, IFormFile?> MaxFileSizeWithMessage(int maxSize)
		{
			return ruleBuilder
				.Must(formFile => formFile == null || formFile.Length <= maxSize)
				.WithMessage((_, typeProperty) => CommonValidationErrorMessages.GetMaxFileSize(PropertyNamePlaceholder, typeProperty!.Length, maxSize));
		}

		public IRuleBuilderOptions<T, IFormFile?> ContentTypeWithMessage(ICollection<string> contentTypes)
		{
			return ruleBuilder
				.Must(formFile => formFile == null || contentTypes.Any(contentType => contentType.EqualsOrdinalIgnoreCase(formFile.ContentType)))
				.WithMessage(CommonValidationErrorMessages.GetInvalidContentType(PropertyNamePlaceholder, contentTypes));
		}
	}

	extension<T, TElement>(IRuleBuilder<T, ICollection<TElement>> ruleBuilder)
	{
		public IRuleBuilderOptions<T, ICollection<TElement>> MaxCountWithMessage(int maxCount)
		{
			return ruleBuilder
				.Must(elements => elements.Count <= maxCount)
				.WithMessage((_, typeProperty) => CommonValidationErrorMessages.GetMaxCount(PropertyNamePlaceholder, typeProperty.Count, maxCount));
		}
	}
}
