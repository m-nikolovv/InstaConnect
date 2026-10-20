namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Collections;

internal class UserCollection : MongoDbCollection<User>, IUserCollection
{
	private readonly IUserFluentFactory _fluentFactory;

	public UserCollection(
		ISessionHandler sessionHandler,
		IUserFluentFactory fluentFactory,
		IMongoCollection<User> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
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
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
