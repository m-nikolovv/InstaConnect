using InstaConnect.Posts.Domain.Features.PostComments.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Posts.Application.Features.PostComments.Extensions;

internal static class RuleBuilderExtensions
{
	extension<T>(IRuleBuilder<T, string> ruleBuilder)
	{
		public IRuleBuilderOptions<T, string> PostCommentIdMinLengthWithMessage()
		{
			return ruleBuilder.MinLengthWithMessage(PostCommentConfigurations.IdMinLength);
		}

		public IRuleBuilderOptions<T, string> PostCommentIdMaxLengthWithMessage()
		{
			return ruleBuilder.MaxLengthWithMessage(PostCommentConfigurations.IdMaxLength);
		}

		public IRuleBuilderOptions<T, string> PostCommentContentMinLengthWithMessage()
		{
			return ruleBuilder.MinLengthWithMessage(PostCommentConfigurations.ContentMinLength);
		}

		public IRuleBuilderOptions<T, string> PostCommentContentMaxLengthWithMessage()
		{
			return ruleBuilder.MaxLengthWithMessage(PostCommentConfigurations.ContentMaxLength);
		}
	}

	extension<T>(IRuleBuilder<T, int> ruleBuilder)
	{
		public IRuleBuilderOptions<T, int> PostCommentPageMinValueWithMessage()
		{
			return ruleBuilder.MinValueWithMessage(PostCommentConfigurations.PageMinValue);
		}

		public IRuleBuilderOptions<T, int> PostCommentPageMaxValueWithMessage()
		{
			return ruleBuilder.MaxValueWithMessage(PostCommentConfigurations.PageMaxValue);
		}

		public IRuleBuilderOptions<T, int> PostCommentPageSizeMinValueWithMessage()
		{
			return ruleBuilder.MinValueWithMessage(PostCommentConfigurations.PageSizeMinValue);
		}

		public IRuleBuilderOptions<T, int> PostCommentPageSizeMaxValueWithMessage()
		{
			return ruleBuilder.MaxValueWithMessage(PostCommentConfigurations.PageSizeMaxValue);
		}
	}

	extension<T>(IRuleBuilder<T, ICollection<IFormFile>> ruleBuilder)
	{
		public IRuleBuilderOptions<T, ICollection<IFormFile>> PostCommentImagesMaxCountWithMessage()
		{
			return ruleBuilder.MaxCountWithMessage(PostCommentConfigurations.ImagesMaxCount);
		}
	}
}
