using InstaConnect.Common.Domain.Features.AccessTokens.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Builders;

public class AddUserClaimCommandBuilder
{
	private string _id;
	private ApplicationClaims _claim;

	public AddUserClaimCommandBuilder(User user)
	{
		_id = user.Id.Id;
		_claim = UserClaimDataFaker.GetClaim();
	}

	public AddUserClaimCommandBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public AddUserClaimCommandBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public AddUserClaimCommandBuilder WithClaim(IEnumTransformer<ApplicationClaims> transformer)
	{
		_claim = transformer.Transform(_claim);

		return this;
	}

	public AddUserClaimCommand Build()
	{
		return new(
			new(_id),
			_claim);
	}
}
