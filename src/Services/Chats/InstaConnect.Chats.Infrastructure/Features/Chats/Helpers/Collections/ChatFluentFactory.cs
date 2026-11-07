using InstaConnect.Chats.Domain.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Collections;

internal class ChatFluentFactory : IChatFluentFactory
{
	private readonly IChatIncluderFactory _includerFactory;
	private readonly IChatIncludeBuilderFactory _includeBuilderFactory;
	private readonly IChatResponseFluentFactory _responseFluentFactory;

	public ChatFluentFactory(
		IChatIncluderFactory includerFactory,
		IChatIncludeBuilderFactory includeBuilderFactory,
		IChatResponseFluentFactory responseFluentFactory)
	{
		_includerFactory = includerFactory;
		_includeBuilderFactory = includeBuilderFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IChatFluent Create(IAggregateFluent<Chat> fluent)
	{
		return new ChatFluent(fluent, _includerFactory, _includeBuilderFactory, _responseFluentFactory);
	}
}
