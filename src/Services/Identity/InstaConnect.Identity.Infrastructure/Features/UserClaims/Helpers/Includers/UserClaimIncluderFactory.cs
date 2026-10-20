namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Includers;

internal class UserClaimIncluderFactory : IUserClaimIncluderFactory
{
	private readonly IEnumerable<IUserClaimIncluder> _includers;

	public UserClaimIncluderFactory(IEnumerable<IUserClaimIncluder> includers)
	{
		_includers = includers;
	}

	public IEnumerable<IUserClaimIncluder> Create(ICollection<IdentityIncludeDescriptor> descriptors)
	{
		var includers = _includers.Where(s => descriptors.Any(p =>
														p.IncludeType == s.IncludeType &&
														p.DestinationType == s.DestinationType));

		return includers;
	}
}
