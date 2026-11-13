namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Collections;

internal class ChatMessageResponseFluentFactory : IChatMessageResponseFluentFactory
{
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public ChatMessageResponseFluentFactory(IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_fluentHandlerFactory = fluentHandlerFactory;
	}

	public IChatMessageResponseFluent Create(IAggregateFluent<ChatMessageResponse> fluent)
	{
		return new ChatMessageResponseFluent(_fluentHandlerFactory.CreateResponse(fluent));
	}
}
