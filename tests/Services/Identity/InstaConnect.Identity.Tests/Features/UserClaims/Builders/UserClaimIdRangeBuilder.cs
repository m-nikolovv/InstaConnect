namespace InstaConnect.Identity.Tests.Features.UserClaims.Builders;

public class UserClaimIdRangeBuilder
{
	private readonly ICollection<UserClaimIdBuilder> _idBuilders;

	public UserClaimIdRangeBuilder(ICollection<UserClaimIdBuilder> idBuilders)
	{
		_idBuilders = idBuilders;
	}

	public UserClaimIdRangeBuilder WithId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithId(transformer);
		}

		return this;
	}

	public ICollection<UserClaimId> Build()
	{
		return [.. _idBuilders.Select(idBuilder => idBuilder.Build())];
	}
}
