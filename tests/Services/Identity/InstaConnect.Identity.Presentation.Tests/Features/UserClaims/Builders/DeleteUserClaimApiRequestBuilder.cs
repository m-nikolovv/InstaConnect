namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Builders;

public class DeleteUserClaimApiRequestBuilder
{
	private string _id;
	private ApplicationClaims _claim;

	public DeleteUserClaimApiRequestBuilder(UserClaim userClaim)
	{
		_id = userClaim.Id.Id.Id;
		_claim = userClaim.Id.Claim;
	}

	public DeleteUserClaimApiRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public DeleteUserClaimApiRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public DeleteUserClaimApiRequestBuilder WithClaim(IEnumTransformer<ApplicationClaims> transformer)
	{
		_claim = transformer.Transform(_claim);

		return this;
	}

	public DeleteUserClaimApiRequest Build()
	{
		return new(_id, _claim);
	}
}
