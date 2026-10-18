using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Collections;

internal class ChatMessageImageFluentFactory : IChatMessageImageFluentFactory
{
	public IChatMessageImageFluent Create(IAggregateFluent<ChatMessageImage> fluent)
	{
		return new ChatMessageImageFluent(fluent);
	}
}
