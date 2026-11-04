namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Includers;

internal class RefreshTokenIncluderFactory
	: IncluderFactory<IdentityIncludeType, IdentityDestinationType, IdentityIncludeDescriptor, IRefreshTokenIncluder, RefreshToken>, IRefreshTokenIncluderFactory
{
	public RefreshTokenIncluderFactory(IEnumerable<IRefreshTokenIncluder> includers) : base(includers)
	{
	}
}
