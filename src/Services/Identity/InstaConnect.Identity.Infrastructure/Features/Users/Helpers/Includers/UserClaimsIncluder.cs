namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includers;

internal class UserClaimsIncluder : IUserIncluder
{
	private readonly IMongoCollection<UserClaim> _collection;

	public UserClaimsIncluder(IMongoCollection<UserClaim> collection)
	{
		_collection = collection;
	}

	public IdentityDestinationType DestinationType => IdentityDestinationType.User;

	public IdentityIncludeType IncludeType => IdentityIncludeType.UserClaim;

	public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				l => l.Id.Id,
				p => p.UserClaims
			);
	}
}
