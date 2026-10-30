using InstaConnect.Chats.Domain.Features.ChatMessageImages.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.InvalidContentType;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Images;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessageImagesInvalidContentTypeWithMessageDataAttribute : InvalidContentTypeFormFileCollectionWithMessageDataAttribute
{
	public ChatMessageImagesInvalidContentTypeWithMessageDataAttribute()
		: base(ChatMessageImageConfigurations.ImageContentTypes)
	{
	}
}
