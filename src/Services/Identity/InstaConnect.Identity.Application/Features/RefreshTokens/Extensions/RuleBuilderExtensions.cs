using InstaConnect.Identity.Domain.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Application.Features.RefreshTokens.Extensions;

internal static class RuleBuilderExtensions
{
	extension<T>(IRuleBuilder<T, string> ruleBuilder)
	{
		public IRuleBuilderOptions<T, string> RefreshTokenValueMinLengthWithMessage()
		{
			return ruleBuilder.MinLengthWithMessage(RefreshTokenConfigurations.ValueMinLength);
		}

		public IRuleBuilderOptions<T, string> RefreshTokenValueMaxLengthWithMessage()
		{
			return ruleBuilder.MaxLengthWithMessage(RefreshTokenConfigurations.ValueMaxLength);
		}
	}
}
