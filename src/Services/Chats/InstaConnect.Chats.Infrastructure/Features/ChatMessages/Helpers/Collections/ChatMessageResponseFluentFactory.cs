namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Collections;

internal class ChatMessageResponseFluentFactory : IChatMessageResponseFluentFactory
{
	public IChatMessageResponseFluent Create(IAggregateFluent<ChatMessageResponse> fluent)
	{
		return new ChatMessageResponseFluent(fluent);
	}
}
