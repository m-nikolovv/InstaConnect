namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageFluentFactory
{
	public IChatMessageFluent Create(IAggregateFluent<ChatMessage> fluent);
}
