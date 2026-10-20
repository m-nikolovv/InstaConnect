using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Extensions;

internal static class RuleBuilderExtensions
{
	extension<T>(IRuleBuilder<T, string> ruleBuilder)
	{
		public IRuleBuilderOptions<T, string> EmailConfirmationTokenValueMinLengthWithMessage()
		{
			return ruleBuilder.MinLengthWithMessage(EmailConfirmationTokenConfigurations.ValueMinLength);
		}

		public IRuleBuilderOptions<T, string> EmailConfirmationTokenValueMaxLengthWithMessage()
		{
			return ruleBuilder.MaxLengthWithMessage(EmailConfirmationTokenConfigurations.ValueMaxLength);
		}
	}
}
