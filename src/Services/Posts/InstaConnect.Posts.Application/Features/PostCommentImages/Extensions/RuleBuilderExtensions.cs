using InstaConnect.Posts.Domain.Features.PostCommentImages.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Posts.Application.Features.PostCommentImages.Extensions;

internal static class RuleBuilderExtensions
{
	extension<T>(IRuleBuilder<T, IFormFile?> ruleBuilder)
	{
		public IRuleBuilderOptions<T, IFormFile?> PostCommentImageMaxSizeWithMessage()
		{
			return ruleBuilder.MaxFileSizeWithMessage(PostCommentImageConfigurations.ImageMaxSize);
		}

		public IRuleBuilderOptions<T, IFormFile?> PostCommentImageContentTypeWithMessage()
		{
			return ruleBuilder.ContentTypeWithMessage(PostCommentImageConfigurations.ImageContentTypes);
		}
	}
}
