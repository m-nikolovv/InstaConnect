using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Collections;

internal class ChatCollection : MongoDbCollection<Chat, ChatId>, IChatCollection
{
	private readonly IChatCacheHandler _cacheHandler;
	private readonly IChatFluentFactory _fluentFactory;
	private readonly IChatMessageCollection _messageCollection;

	public ChatCollection(
		ISessionHandler sessionHandler,
		IChatCacheHandler cacheHandler,
		IChatFluentFactory fluentFactory,
		IMongoCollection<Chat> collection,
		IChatMessageCollection messageCollection) : base(sessionHandler, collection)
	{
		_cacheHandler = cacheHandler;
		_fluentFactory = fluentFactory;
		_messageCollection = messageCollection;
	}

	public IChatFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		Chat entity,
		CancellationToken cancellationToken)
	{
		await _messageCollection.AddByParentAsync(entity.Id.GetChatMessageByParentFilter(), cancellationToken);
		await InsertAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task AddByParentAsync(
		FilterDefinition<Chat> filter,
		CancellationToken cancellationToken)
	{
		await UpdateByParentAsync(filter, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<Chat> entities,
		CancellationToken cancellationToken)
	{
		await _messageCollection.AddByParentAsync(entities.Select(p => p.Id).GetChatMessageByParentFilter(), cancellationToken);
		await InsertRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task UpdateByParentAsync(
		FilterDefinition<Chat> filter,
		CancellationToken cancellationToken)
	{
		var chatIds = await GetIdsAsync(filter, cancellationToken);

		await _messageCollection.UpdateByParentAsync(chatIds.GetChatMessageByParentFilter(), cancellationToken);
		await _cacheHandler.DeleteRangeAsync(chatIds);
	}

	public async Task DeleteAsync(
		Chat entity,
		CancellationToken cancellationToken)
	{
		await _messageCollection.DeleteByParentAsync(entity.Id.GetChatMessageByParentFilter(), cancellationToken);
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<Chat> filter,
		CancellationToken cancellationToken)
	{
		var chatIds = await GetIdsAsync(filter, cancellationToken);

		await _messageCollection.DeleteByParentAsync(chatIds.GetChatMessageByParentFilter(), cancellationToken);
		await RemoveRangeAsync(filter, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(chatIds);
	}
}
