using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Collections;

internal class ChatMessageImageCollection : IChatMessageImageCollection
{
	private readonly IChatMessageImageFluentFactory _fluentFactory;
	private readonly IMongoDbCollectionHandler<ChatMessageImage, ChatMessageImageId> _collectionHandler;

	public ChatMessageImageCollection(
		IChatMessageImageFluentFactory fluentFactory,
		IMongoDbCollectionHandler<ChatMessageImage, ChatMessageImageId> collectionHandler)
	{
		_fluentFactory = fluentFactory;
		_collectionHandler = collectionHandler;
	}

	public IChatMessageImageFluent AggregateFluent()
	{
		var fluent = _collectionHandler.AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		ChatMessageImage entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<ChatMessageImage> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(
		ChatMessageImage entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<ChatMessageImage> filter,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveRangeAsync(filter, cancellationToken);
	}

	public async Task DeleteRangeAsync(
		IEnumerable<ChatMessageImage> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveRangeAsync(entities.Select(p => p.Id).GetFilter(), cancellationToken);
	}
}
