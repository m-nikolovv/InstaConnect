using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Collections;

internal class ChatMessageImageFluent : MongoDbFluent<ChatMessageImage>, IChatMessageImageFluent
{
	public ChatMessageImageFluent(IAggregateFluent<ChatMessageImage> fluent) : base(fluent)
	{
	}

	public IChatMessageImageFluent Match(ChatMessageImageId filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IChatMessageImageFluent Match(IEnumerable<ChatMessageImageId> filter)
	{
		Match(filter.GetFilter());

		return this;
	}
}
