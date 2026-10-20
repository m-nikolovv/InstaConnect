namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Includers;

internal class UserIncluder : IForgotPasswordTokenIncluder
{
	private readonly IMongoCollection<User> _collection;

	public UserIncluder(IMongoCollection<User> collection)
	{
		_collection = collection;
	}

	public IdentityDestinationType DestinationType => IdentityDestinationType.ForgotPasswordToken;

	public IdentityIncludeType IncludeType => IdentityIncludeType.User;

	public IAggregateFluent<ForgotPasswordToken> Include(IAggregateFluent<ForgotPasswordToken> aggregate)
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
