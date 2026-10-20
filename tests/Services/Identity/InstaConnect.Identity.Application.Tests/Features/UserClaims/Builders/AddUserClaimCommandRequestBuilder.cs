using InstaConnect.Common.Domain.Features.AccessTokens.Models;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Builders;

public class AddUserClaimCommandRequestBuilder
{
	private string _id;
	private ApplicationClaims _claim;

	public AddUserClaimCommandRequestBuilder(User user)
	{
		_id = user.Id.Id;
		_claim = UserClaimDataFaker.GetClaim();
	}

	public AddUserClaimCommandRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public AddUserClaimCommandRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public AddUserClaimCommandRequestBuilder WithClaim(IEnumTransformer<ApplicationClaims> transformer)
	{
		_claim = transformer.Transform(_claim);

		return this;
	}

	public AddUserClaimCommandRequest Build()
	{
		return new(_id, _claim);
	}
}
