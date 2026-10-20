namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Builders;

public class AddUserClaimApiRequestBuilder
{
	private string _id;
	private ApplicationClaims _claim;

	public AddUserClaimApiRequestBuilder(User user)
	{
		_id = user.Id.Id;
		_claim = UserClaimDataFaker.GetClaim();
	}

	public AddUserClaimApiRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public AddUserClaimApiRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public AddUserClaimApiRequestBuilder WithClaim(IEnumTransformer<ApplicationClaims> transformer)
	{
		_claim = transformer.Transform(_claim);

		return this;
	}

	public AddUserClaimApiRequest Build()
	{
		return new(_id, new(_claim));
	}
}
