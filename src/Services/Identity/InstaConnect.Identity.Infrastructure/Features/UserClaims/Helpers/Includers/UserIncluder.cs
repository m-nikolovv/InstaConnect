namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Includers;

internal class UserIncluder : IUserClaimIncluder
{
	private readonly IMongoCollection<User> _collection;

	public UserIncluder(IMongoCollection<User> collection)
	{
		_collection = collection;
	}

	public IdentityDestinationType DestinationType => IdentityDestinationType.UserClaim;

	public IdentityIncludeType IncludeType => IdentityIncludeType.User;

	public IAggregateFluent<UserClaim> Include(IAggregateFluent<UserClaim> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				p => p.Id.Id,
				l => l.Id,
				p => p.User!
			);
	}
}
