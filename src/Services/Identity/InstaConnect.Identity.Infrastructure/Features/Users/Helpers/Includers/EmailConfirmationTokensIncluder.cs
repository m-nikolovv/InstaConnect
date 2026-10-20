namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includers;

internal class EmailConfirmationTokensIncluder : IUserIncluder
{
	private readonly IMongoCollection<EmailConfirmationToken> _collection;

	public EmailConfirmationTokensIncluder(IMongoCollection<EmailConfirmationToken> collection)
	{
		_collection = collection;
	}

	public IdentityDestinationType DestinationType => IdentityDestinationType.User;

	public IdentityIncludeType IncludeType => IdentityIncludeType.EmailConfirmationToken;

	public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				l => l.Id.Id,
				p => p.EmailConfirmationTokens
			);
	}
}
