using InstaConnect.Posts.Domain.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Application.Features.PostLikes.Extensions;

internal static class RuleBuilderExtensions
{
	extension<T>(IRuleBuilder<T, int> ruleBuilder)
	{
		public IRuleBuilderOptions<T, int> PostLikePageMinValueWithMessage()
		{
			return ruleBuilder.MinValueWithMessage(PostLikeConfigurations.PageMinValue);
		}

		public IRuleBuilderOptions<T, int> PostLikePageMaxValueWithMessage()
		{
			return ruleBuilder.MaxValueWithMessage(PostLikeConfigurations.PageMaxValue);
		}

		public IRuleBuilderOptions<T, int> PostLikePageSizeMinValueWithMessage()
		{
			return ruleBuilder.MinValueWithMessage(PostLikeConfigurations.PageSizeMinValue);
		}

		public IRuleBuilderOptions<T, int> PostLikePageSizeMaxValueWithMessage()
		{
			return ruleBuilder.MaxValueWithMessage(PostLikeConfigurations.PageSizeMaxValue);
		}
	}
}
