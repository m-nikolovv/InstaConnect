using InstaConnect.Common.Domain.Features.AccessTokens.Models;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Builders;

public class DeleteUserClaimCommandBuilder
{
	private string _id;
	private ApplicationClaims _claim;

	public DeleteUserClaimCommandBuilder(UserClaim userClaim)
	{
		_id = userClaim.Id.Id.Id;
		_claim = userClaim.Id.Claim;
	}

	public DeleteUserClaimCommandBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public DeleteUserClaimCommandBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public DeleteUserClaimCommandBuilder WithClaim(IEnumTransformer<ApplicationClaims> transformer)
	{
		_claim = transformer.Transform(_claim);

		return this;
	}

	public DeleteUserClaimCommand Build()
	{
		return new(
			new(
				new(_id),
				_claim));
	}
}
