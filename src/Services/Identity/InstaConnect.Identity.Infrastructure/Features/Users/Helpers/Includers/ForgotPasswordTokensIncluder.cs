namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includers;

internal class ForgotPasswordTokensIncluder : IUserIncluder
{
	private readonly IMongoCollection<ForgotPasswordToken> _collection;

	public ForgotPasswordTokensIncluder(IMongoCollection<ForgotPasswordToken> collection)
	{
		_collection = collection;
	}

	public IdentityDestinationType DestinationType => IdentityDestinationType.User;

	public IdentityIncludeType IncludeType => IdentityIncludeType.ForgotPasswordToken;

	public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				l => l.Id.Id,
				p => p.ForgotPasswordTokens
			);
	}
}
