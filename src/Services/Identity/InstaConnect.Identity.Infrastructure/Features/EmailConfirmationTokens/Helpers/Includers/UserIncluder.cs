namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Includers;

internal class UserIncluder : IEmailConfirmationTokenIncluder
{
	private readonly IMongoCollection<User> _collection;

	public UserIncluder(IMongoCollection<User> collection)
	{
		_collection = collection;
	}

	public IdentityDestinationType DestinationType => IdentityDestinationType.EmailConfirmationToken;

	public IdentityIncludeType IncludeType => IdentityIncludeType.User;

	public IAggregateFluent<EmailConfirmationToken> Include(IAggregateFluent<EmailConfirmationToken> aggregate)
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
