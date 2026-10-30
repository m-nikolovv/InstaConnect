using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.TooMany;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Images;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessageImagesTooManyWithMessageDataAttribute : TooManyFormFileCollectionWithMessageDataAttribute
{
	public ChatMessageImagesTooManyWithMessageDataAttribute()
		: base(ChatMessageConfigurations.ImagesMaxCount)
	{
	}
}
