namespace InstaConnect.Identity.Tests.Features.UserClaims.Builders;

public class UserClaimIdRangeBuilderFactory
{
	private readonly UserClaimIdBuilderFactory _idBuilderFactory;

	public UserClaimIdRangeBuilderFactory()
	{
		_idBuilderFactory = new();
	}

	public UserClaimIdRangeBuilder Create(ICollection<UserClaimId> ids)
	{
		return new([.. ids.Select(_idBuilderFactory.Create)]);
	}
}
