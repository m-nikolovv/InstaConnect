namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageResponseFluentFactory
{
	public IChatMessageResponseFluent Create(IAggregateFluent<ChatMessageResponse> fluent);
}
