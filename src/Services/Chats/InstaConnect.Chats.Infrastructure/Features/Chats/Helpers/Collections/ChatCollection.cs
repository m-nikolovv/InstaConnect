using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Collections;

internal class ChatCollection : MongoDbCollection<Chat, ChatId>, IChatCollection
{
	private readonly IChatFluentFactory _fluentFactory;
	private readonly IChatMessageCollection _messageCollection;

	public ChatCollection(
		ISessionHandler sessionHandler,
		IChatFluentFactory fluentFactory,
		IMongoCollection<Chat> collection,
		IChatMessageCollection messageCollection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
		_messageCollection = messageCollection;
	}

	public IChatFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task DeleteAsync(
		Chat entity,
		CancellationToken cancellationToken)
	{
		await CascadeDeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task CascadeDeleteAsync(
		FilterDefinition<Chat> filter,
		CancellationToken cancellationToken)
	{
		var chatIds = await GetIdsAsync(filter, cancellationToken);

		await _messageCollection.CascadeDeleteAsync(chatIds.GetChatMessageCascadeFilter(), cancellationToken);
		await DeleteRangeAsync(filter, cancellationToken);
	}
}
