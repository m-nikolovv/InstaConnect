using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Extensions;

internal static class RuleBuilderExtensions
{
	extension<T>(IRuleBuilder<T, string> ruleBuilder)
	{
		public IRuleBuilderOptions<T, string> ForgotPasswordTokenValueMinLengthWithMessage()
		{
			return ruleBuilder.MinLengthWithMessage(ForgotPasswordTokenConfigurations.ValueMinLength);
		}

		public IRuleBuilderOptions<T, string> ForgotPasswordTokenValueMaxLengthWithMessage()
		{
			return ruleBuilder.MaxLengthWithMessage(ForgotPasswordTokenConfigurations.ValueMaxLength);
		}
	}
}
