using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Collections;

internal class ChatMessageCollection : MongoDbCollection<ChatMessage, ChatMessageId>, IChatMessageCollection
{
	private readonly IChatMessageFluentFactory _fluentFactory;
	private readonly IChatMessageImageCollection _messageImageCollection;

	public ChatMessageCollection(
		ISessionHandler sessionHandler,
		IChatMessageFluentFactory fluentFactory,
		IMongoCollection<ChatMessage> collection,
		IChatMessageImageCollection messageImageCollection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
		_messageImageCollection = messageImageCollection;
	}

	public IChatMessageFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task UpdateAsync(
		ChatMessage entity,
		CancellationToken cancellationToken)
	{
		await UpdateAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		ChatMessage entity,
		CancellationToken cancellationToken)
	{
		await CascadeDeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task CascadeDeleteAsync(
		FilterDefinition<ChatMessage> filter,
		CancellationToken cancellationToken)
	{
		var messageIds = await GetIdsAsync(filter, cancellationToken);

		await _messageImageCollection.CascadeDeleteAsync(messageIds.GetChatMessageImageCascadeFilter(), cancellationToken);
		await DeleteRangeAsync(filter, cancellationToken);
	}
}
