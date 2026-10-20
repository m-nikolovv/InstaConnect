using InstaConnect.Identity.Domain.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Application.Features.UserClaims.Extensions;

internal static class RuleBuilderExtensions
{
	extension<T>(IRuleBuilder<T, int> ruleBuilder)
	{
		public IRuleBuilderOptions<T, int> UserClaimPageMinValueWithMessage()
		{
			return ruleBuilder.MinValueWithMessage(UserClaimConfigurations.PageMinValue);
		}

		public IRuleBuilderOptions<T, int> UserClaimPageMaxValueWithMessage()
		{
			return ruleBuilder.MaxValueWithMessage(UserClaimConfigurations.PageMaxValue);
		}

		public IRuleBuilderOptions<T, int> UserClaimPageSizeMinValueWithMessage()
		{
			return ruleBuilder.MinValueWithMessage(UserClaimConfigurations.PageSizeMinValue);
		}

		public IRuleBuilderOptions<T, int> UserClaimPageSizeMaxValueWithMessage()
		{
			return ruleBuilder.MaxValueWithMessage(UserClaimConfigurations.PageSizeMaxValue);
		}
	}
}
