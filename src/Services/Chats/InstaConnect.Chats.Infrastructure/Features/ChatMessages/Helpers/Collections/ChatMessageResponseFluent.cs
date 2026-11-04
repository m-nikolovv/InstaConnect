namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Collections;

internal class ChatMessageResponseFluent :
	MongoDbResponseFluent<ChatMessageResponse>, IChatMessageResponseFluent
{
	public ChatMessageResponseFluent(IAggregateFluent<ChatMessageResponse> fluent) : base(fluent)
	{
	}
}
