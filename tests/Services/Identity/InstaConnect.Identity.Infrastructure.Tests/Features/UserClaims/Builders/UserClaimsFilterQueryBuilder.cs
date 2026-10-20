namespace InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Builders;

public class UserClaimsFilterQueryBuilder
{
	private string _id;

	public UserClaimsFilterQueryBuilder(UserClaim userClaim)
	{
		_id = userClaim.Id.Id.Id;
	}

	public UserClaimsFilterQueryBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public UserClaimsFilterQuery Build()
	{
		return new(new(_id));
	}
}
