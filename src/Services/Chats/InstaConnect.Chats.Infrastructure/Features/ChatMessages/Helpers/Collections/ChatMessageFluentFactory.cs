namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Collections;

internal class ChatMessageFluentFactory : IChatMessageFluentFactory
{
	private readonly IChatMessageIncluderFactory _includerFactory;
	private readonly IChatMessageResponseFluentFactory _responseFluentFactory;

	public ChatMessageFluentFactory(IChatMessageIncluderFactory includerFactory, IChatMessageResponseFluentFactory responseFluentFactory)
	{
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IChatMessageFluent Create(IAggregateFluent<ChatMessage> fluent)
	{
		return new ChatMessageFluent(fluent, _includerFactory, _responseFluentFactory);
	}
}
