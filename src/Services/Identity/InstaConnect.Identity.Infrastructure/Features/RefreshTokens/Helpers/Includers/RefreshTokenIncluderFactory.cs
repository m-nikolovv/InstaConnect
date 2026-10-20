namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Includers;

internal class RefreshTokenIncluderFactory : IRefreshTokenIncluderFactory
{
	private readonly IEnumerable<IRefreshTokenIncluder> _includers;

	public RefreshTokenIncluderFactory(IEnumerable<IRefreshTokenIncluder> includers)
	{
		_includers = includers;
	}

	public IEnumerable<IRefreshTokenIncluder> Create(ICollection<IdentityIncludeDescriptor> descriptors)
	{
		var includers = _includers.Where(s => descriptors.Any(p =>
														p.IncludeType == s.IncludeType &&
														p.DestinationType == s.DestinationType));

		return includers;
	}
}
