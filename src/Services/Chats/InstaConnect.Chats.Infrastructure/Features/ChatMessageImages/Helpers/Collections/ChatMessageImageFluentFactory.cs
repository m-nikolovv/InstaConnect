using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Collections;

internal class ChatMessageImageFluentFactory : IChatMessageImageFluentFactory
{
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public ChatMessageImageFluentFactory(IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_fluentHandlerFactory = fluentHandlerFactory;
	}

	public IChatMessageImageFluent Create(IAggregateFluent<ChatMessageImage> fluent)
	{
		return new ChatMessageImageFluent(_fluentHandlerFactory.Create<ChatMessageImage, ChatMessageImageId>(fluent));
	}
}
