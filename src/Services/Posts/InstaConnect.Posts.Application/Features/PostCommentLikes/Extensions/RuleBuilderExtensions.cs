using InstaConnect.Posts.Domain.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Extensions;

internal static class RuleBuilderExtensions
{
	extension<T>(IRuleBuilder<T, int> ruleBuilder)
	{
		public IRuleBuilderOptions<T, int> PostCommentLikePageMinValueWithMessage()
		{
			return ruleBuilder.MinValueWithMessage(PostCommentLikeConfigurations.PageMinValue);
		}

		public IRuleBuilderOptions<T, int> PostCommentLikePageMaxValueWithMessage()
		{
			return ruleBuilder.MaxValueWithMessage(PostCommentLikeConfigurations.PageMaxValue);
		}

		public IRuleBuilderOptions<T, int> PostCommentLikePageSizeMinValueWithMessage()
		{
			return ruleBuilder.MinValueWithMessage(PostCommentLikeConfigurations.PageSizeMinValue);
		}

		public IRuleBuilderOptions<T, int> PostCommentLikePageSizeMaxValueWithMessage()
		{
			return ruleBuilder.MaxValueWithMessage(PostCommentLikeConfigurations.PageSizeMaxValue);
		}
	}
}
