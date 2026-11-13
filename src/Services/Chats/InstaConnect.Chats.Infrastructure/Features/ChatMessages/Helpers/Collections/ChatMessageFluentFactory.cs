namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Collections;

internal class ChatMessageFluentFactory : IChatMessageFluentFactory
{
	private readonly IChatMessageIncluderFactory _includerFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;
	private readonly IChatMessageResponseFluentFactory _responseFluentFactory;

	public ChatMessageFluentFactory(
		IChatMessageIncluderFactory includerFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory,
		IChatMessageResponseFluentFactory responseFluentFactory)
	{
		_includerFactory = includerFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IChatMessageFluent Create(IAggregateFluent<ChatMessage> fluent)
	{
		return new ChatMessageFluent(
			_includerFactory,
			_responseFluentFactory,
			_fluentHandlerFactory.Create<ChatMessage, ChatMessageId>(fluent));
	}
}
