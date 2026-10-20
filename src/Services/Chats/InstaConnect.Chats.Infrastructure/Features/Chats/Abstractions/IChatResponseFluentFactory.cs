namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatResponseFluentFactory
{
	public IChatResponseFluent Create(IAggregateFluent<ChatResponse> fluent);
}
