using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Collections;

internal class UserCollection : MongoDbCollection<User, UserId>, IUserCollection
{
	private readonly IChatCollection _chatCollection;
	private readonly IUserFluentFactory _fluentFactory;

	public UserCollection(
		ISessionHandler sessionHandler,
		IChatCollection chatCollection,
		IUserFluentFactory fluentFactory,
		IMongoCollection<User> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
		_chatCollection = chatCollection;
	}

	public IUserFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task UpdateAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await UpdateAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _chatCollection.CascadeDeleteAsync(entity.Id.GetChatCascadeFilter(), cancellationToken);
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
