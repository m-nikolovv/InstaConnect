namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Includers;

internal class UserIncluder : IRefreshTokenIncluder
{
	private readonly IMongoCollection<User> _collection;

	public UserIncluder(IMongoCollection<User> collection)
	{
		_collection = collection;
	}

	public IdentityDestinationType DestinationType => IdentityDestinationType.RefreshToken;

	public IdentityIncludeType IncludeType => IdentityIncludeType.User;

	public IAggregateFluent<RefreshToken> Include(IAggregateFluent<RefreshToken> aggregate)
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
