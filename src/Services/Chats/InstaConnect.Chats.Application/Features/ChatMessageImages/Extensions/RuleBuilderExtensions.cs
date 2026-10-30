using InstaConnect.Chats.Domain.Features.ChatMessageImages.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Chats.Application.Features.ChatMessageImages.Extensions;

internal static class RuleBuilderExtensions
{
	extension<T>(IRuleBuilder<T, IFormFile?> ruleBuilder)
	{
		public IRuleBuilderOptions<T, IFormFile?> ChatMessageImageMaxSizeWithMessage()
		{
			return ruleBuilder.MaxFileSizeWithMessage(ChatMessageImageConfigurations.ImageMaxSize);
		}

		public IRuleBuilderOptions<T, IFormFile?> ChatMessageImageContentTypeWithMessage()
		{
			return ruleBuilder.ContentTypeWithMessage(ChatMessageImageConfigurations.ImageContentTypes);
		}
	}
}
