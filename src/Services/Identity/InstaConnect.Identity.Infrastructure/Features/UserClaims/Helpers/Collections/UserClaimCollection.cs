using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Collections;

internal class UserClaimCollection : MongoDbCollection<UserClaim>, IUserClaimCollection
{
	private readonly IUserClaimFluentFactory _fluentFactory;

	public UserClaimCollection(
		ISessionHandler sessionHandler,
		IUserClaimFluentFactory fluentFactory,
		IMongoCollection<UserClaim> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
	}

	public IUserClaimFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task DeleteAsync(
		UserClaim entity,
		CancellationToken cancellationToken)
	{
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
