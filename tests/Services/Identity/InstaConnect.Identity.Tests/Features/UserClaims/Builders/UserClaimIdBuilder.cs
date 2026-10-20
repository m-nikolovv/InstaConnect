namespace InstaConnect.Identity.Tests.Features.UserClaims.Builders;

public class UserClaimIdBuilder
{
	private string _id;
	private readonly ApplicationClaims _claim;

	public UserClaimIdBuilder(UserClaimId id)
	{
		_id = id.Id.Id;
		_claim = id.Claim;
	}

	public UserClaimIdBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public UserClaimId Build()
	{
		return new(new(_id), _claim);
	}
}
