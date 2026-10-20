namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatFluentFactory
{
	public IChatFluent Create(IAggregateFluent<Chat> fluent);
}
