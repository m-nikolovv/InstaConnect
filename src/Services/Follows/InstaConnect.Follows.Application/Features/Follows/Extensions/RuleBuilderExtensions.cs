using InstaConnect.Follows.Domain.Features.Follows.Utilities;

namespace InstaConnect.Follows.Application.Features.Follows.Extensions;

internal static class RuleBuilderExtensions
{
	extension<T>(IRuleBuilder<T, int> ruleBuilder)
	{
		public IRuleBuilderOptions<T, int> FollowPageMinValueWithMessage()
		{
			return ruleBuilder.MinValueWithMessage(FollowConfigurations.PageMinValue);
		}

		public IRuleBuilderOptions<T, int> FollowPageMaxValueWithMessage()
		{
			return ruleBuilder.MaxValueWithMessage(FollowConfigurations.PageMaxValue);
		}

		public IRuleBuilderOptions<T, int> FollowPageSizeMinValueWithMessage()
		{
			return ruleBuilder.MinValueWithMessage(FollowConfigurations.PageSizeMinValue);
		}

		public IRuleBuilderOptions<T, int> FollowPageSizeMaxValueWithMessage()
		{
			return ruleBuilder.MaxValueWithMessage(FollowConfigurations.PageSizeMaxValue);
		}
	}
}
