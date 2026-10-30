using InstaConnect.Posts.Domain.Features.PostImages.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Posts.Application.Features.PostImages.Extensions;

internal static class RuleBuilderExtensions
{
	extension<T>(IRuleBuilder<T, IFormFile?> ruleBuilder)
	{
		public IRuleBuilderOptions<T, IFormFile?> PostImageMaxSizeWithMessage()
		{
			return ruleBuilder.MaxFileSizeWithMessage(PostImageConfigurations.ImageMaxSize);
		}

		public IRuleBuilderOptions<T, IFormFile?> PostImageContentTypeWithMessage()
		{
			return ruleBuilder.ContentTypeWithMessage(PostImageConfigurations.ImageContentTypes);
		}
	}
}
