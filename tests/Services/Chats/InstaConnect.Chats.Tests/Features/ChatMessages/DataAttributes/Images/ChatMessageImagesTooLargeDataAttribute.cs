using InstaConnect.Chats.Domain.Features.ChatMessageImages.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.TooLarge;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Images;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessageImagesTooLargeDataAttribute : TooLargeFormFileCollectionDataAttribute
{
	public ChatMessageImagesTooLargeDataAttribute()
		: base(ChatMessageImageConfigurations.ImageMaxSize)
	{
	}
}
