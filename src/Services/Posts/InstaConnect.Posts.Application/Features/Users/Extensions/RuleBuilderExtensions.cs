using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.Posts.Application.Features.Users.Extensions;

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
	}

	extension<T>(IRuleBuilder<T, string?> ruleBuilder)
	{
		public IRuleBuilderOptions<T, string?> UserProfileImageUrlMaxLengthWithMessage()
		{
			return ruleBuilder!.MaxLengthWithMessage(UserConfigurations.ProfileImageUrlMaxLength);
		}
	}
}
