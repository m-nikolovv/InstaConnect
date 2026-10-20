using InstaConnect.Common.Domain.Features.AccessTokens.Models;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Builders;

public class DeleteUserClaimCommandRequestBuilder
{
	private string _id;
	private ApplicationClaims _claim;

	public DeleteUserClaimCommandRequestBuilder(UserClaim userClaim)
	{
		_id = userClaim.Id.Id.Id;
		_claim = userClaim.Id.Claim;
	}

	public DeleteUserClaimCommandRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public DeleteUserClaimCommandRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public DeleteUserClaimCommandRequestBuilder WithClaim(IEnumTransformer<ApplicationClaims> transformer)
	{
		_claim = transformer.Transform(_claim);

		return this;
	}

	public DeleteUserClaimCommandRequest Build()
	{
		return new(_id, _claim);
	}
}
