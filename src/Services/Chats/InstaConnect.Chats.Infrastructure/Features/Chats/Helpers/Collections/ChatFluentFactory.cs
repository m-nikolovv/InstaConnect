using InstaConnect.Chats.Domain.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Collections;

internal class ChatFluentFactory : IChatFluentFactory
{
	private readonly IChatIncluderFactory _includerFactory;
	private readonly IChatIncludeBuilderFactory _includeBuilderFactory;
	private readonly IChatResponseFluentFactory _responseFluentFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public ChatFluentFactory(
		IChatIncluderFactory includerFactory,
		IChatIncludeBuilderFactory includeBuilderFactory,
		IChatResponseFluentFactory responseFluentFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_includerFactory = includerFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
		_includeBuilderFactory = includeBuilderFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IChatFluent Create(IAggregateFluent<Chat> fluent)
	{
		return new ChatFluent(_includerFactory, _includeBuilderFactory, _responseFluentFactory, _fluentHandlerFactory.Create<Chat, ChatId>(fluent));
	}
}
