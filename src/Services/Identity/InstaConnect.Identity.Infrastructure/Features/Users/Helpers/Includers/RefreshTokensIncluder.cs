namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includers;

internal class RefreshTokensIncluder : IUserIncluder
{
	private readonly IMongoCollection<RefreshToken> _collection;

	public RefreshTokensIncluder(IMongoCollection<RefreshToken> collection)
	{
		_collection = collection;
	}

	public IdentityDestinationType DestinationType => IdentityDestinationType.User;

	public IdentityIncludeType IncludeType => IdentityIncludeType.RefreshToken;

	public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				l => l.Id.Id,
				p => p.RefreshTokens
			);
	}
}
