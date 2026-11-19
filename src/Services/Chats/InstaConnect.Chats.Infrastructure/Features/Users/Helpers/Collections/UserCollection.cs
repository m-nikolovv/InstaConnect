using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Collections;

internal class UserCollection : IUserCollection
{
	private readonly IChatCollection _chatCollection;
	private readonly IUserFluentFactory _fluentFactory;
	private readonly IMongoDbCollectionHandler<User, UserId> _collectionHandler;

	public UserCollection(
		IChatCollection chatCollection,
		IUserFluentFactory fluentFactory,
		IMongoDbCollectionHandler<User, UserId> collectionHandler)
	{
		_fluentFactory = fluentFactory;
		_chatCollection = chatCollection;
		_collectionHandler = collectionHandler;
	}

	public IUserFluent AggregateFluent()
	{
		var fluent = _collectionHandler.AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<User> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _chatCollection.DeleteByParentAsync(entity.Id.GetChatByParentFilter(), cancellationToken);
		await _collectionHandler.RemoveAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
