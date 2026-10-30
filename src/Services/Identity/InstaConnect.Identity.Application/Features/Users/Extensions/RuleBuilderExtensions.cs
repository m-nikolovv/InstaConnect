using InstaConnect.Identity.Domain.Features.Users.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Application.Features.Users.Extensions;

internal static class RuleBuilderExtensions
{
	extension<T>(IRuleBuilder<T, string> ruleBuilder)
	{
		public IRuleBuilderOptions<T, string> UserIdMinLengthWithMessage()
		{
			return ruleBuilder.MinLengthWithMessage(UserConfigurations.IdMinLength);
		}

		public IRuleBuilderOptions<T, string> UserIdMaxLengthWithMessage()
		{
			return ruleBuilder.MaxLengthWithMessage(UserConfigurations.IdMaxLength);
		}

		public IRuleBuilderOptions<T, string> UserEmailMinLengthWithMessage()
		{
			return ruleBuilder.MinLengthWithMessage(UserConfigurations.EmailMinLength);
		}

		public IRuleBuilderOptions<T, string> UserEmailMaxLengthWithMessage()
		{
			return ruleBuilder.MaxLengthWithMessage(UserConfigurations.EmailMaxLength);
		}

		public IRuleBuilderOptions<T, string> UserFirstNameMinLengthWithMessage()
		{
			return ruleBuilder.MinLengthWithMessage(UserConfigurations.FirstNameMinLength);
		}

		public IRuleBuilderOptions<T, string> UserFirstNameMaxLengthWithMessage()
		{
			return ruleBuilder.MaxLengthWithMessage(UserConfigurations.FirstNameMaxLength);
		}

		public IRuleBuilderOptions<T, string> UserLastNameMinLengthWithMessage()
		{
			return ruleBuilder.MinLengthWithMessage(UserConfigurations.LastNameMinLength);
		}

		public IRuleBuilderOptions<T, string> UserLastNameMaxLengthWithMessage()
		{
			return ruleBuilder.MaxLengthWithMessage(UserConfigurations.LastNameMaxLength);
		}

		public IRuleBuilderOptions<T, string> UserNameMinLengthWithMessage()
		{
			return ruleBuilder.MinLengthWithMessage(UserConfigurations.NameMinLength);
		}

		public IRuleBuilderOptions<T, string> UserNameMaxLengthWithMessage()
		{
			return ruleBuilder.MaxLengthWithMessage(UserConfigurations.NameMaxLength);
		}

		public IRuleBuilderOptions<T, string> UserPasswordMinLengthWithMessage()
		{
			return ruleBuilder.MinLengthWithMessage(UserConfigurations.PasswordMinLength);
		}

		public IRuleBuilderOptions<T, string> UserPasswordMaxLengthWithMessage()
		{
			return ruleBuilder.MaxLengthWithMessage(UserConfigurations.PasswordMaxLength);
		}
	}

	extension<T>(IRuleBuilder<T, int> ruleBuilder)
	{
		public IRuleBuilderOptions<T, int> UserPageMinValueWithMessage()
		{
			return ruleBuilder.MinValueWithMessage(UserConfigurations.PageMinValue);
		}

		public IRuleBuilderOptions<T, int> UserPageMaxValueWithMessage()
		{
			return ruleBuilder.MaxValueWithMessage(UserConfigurations.PageMaxValue);
		}

		public IRuleBuilderOptions<T, int> UserPageSizeMinValueWithMessage()
		{
			return ruleBuilder.MinValueWithMessage(UserConfigurations.PageSizeMinValue);
		}

		public IRuleBuilderOptions<T, int> UserPageSizeMaxValueWithMessage()
		{
			return ruleBuilder.MaxValueWithMessage(UserConfigurations.PageSizeMaxValue);
		}
	}

	extension<T>(IRuleBuilder<T, IFormFile?> ruleBuilder)
	{
		public IRuleBuilderOptions<T, IFormFile?> UserProfileImageMaxSizeWithMessage()
		{
			return ruleBuilder.MaxFileSizeWithMessage(UserConfigurations.ProfileImageMaxSize);
		}

		public IRuleBuilderOptions<T, IFormFile?> UserProfileImageContentTypeWithMessage()
		{
			return ruleBuilder.ContentTypeWithMessage(UserConfigurations.ProfileImageContentTypes);
		}
	}
}
