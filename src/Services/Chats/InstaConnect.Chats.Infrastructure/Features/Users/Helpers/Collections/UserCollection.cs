using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Collections;

internal class UserCollection : MongoDbCollection<User, UserId>, IUserCollection
{
	private readonly IUserCacheHandler _cacheHandler;
	private readonly IChatCollection _chatCollection;
	private readonly IUserFluentFactory _fluentFactory;

	public UserCollection(
		ISessionHandler sessionHandler,
		IUserCacheHandler cacheHandler,
		IChatCollection chatCollection,
		IUserFluentFactory fluentFactory,
		IMongoCollection<User> collection) : base(sessionHandler, collection)
	{
		_cacheHandler = cacheHandler;
		_fluentFactory = fluentFactory;
		_chatCollection = chatCollection;
	}

	public IUserFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _chatCollection.CascadeAddAsync(entity.Id.GetChatCascadeFilter(), cancellationToken);
		await InsertAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task AddRangeAsync(
		IEnumerable<User> entities,
		CancellationToken cancellationToken)
	{
		await InsertRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task UpdateAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _chatCollection.CascadeUpdateAsync(entity.Id.GetChatCascadeFilter(), cancellationToken);
		await ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task DeleteAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _chatCollection.CascadeDeleteAsync(entity.Id.GetChatCascadeFilter(), cancellationToken);
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}
}
