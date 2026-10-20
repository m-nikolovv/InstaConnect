namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Collections;

internal class ChatFluentFactory : IChatFluentFactory
{
	private readonly IChatIncluderFactory _includerFactory;
	private readonly IChatResponseFluentFactory _responseFluentFactory;

	public ChatFluentFactory(IChatIncluderFactory includerFactory, IChatResponseFluentFactory responseFluentFactory)
	{
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IChatFluent Create(IAggregateFluent<Chat> fluent)
	{
		return new ChatFluent(fluent, _includerFactory, _responseFluentFactory);
	}
}
