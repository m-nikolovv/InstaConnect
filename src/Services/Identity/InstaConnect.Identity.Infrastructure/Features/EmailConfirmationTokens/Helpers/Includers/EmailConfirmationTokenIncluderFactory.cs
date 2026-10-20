namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Includers;

internal class EmailConfirmationTokenIncluderFactory : IEmailConfirmationTokenIncluderFactory
{
	private readonly IEnumerable<IEmailConfirmationTokenIncluder> _includers;

	public EmailConfirmationTokenIncluderFactory(IEnumerable<IEmailConfirmationTokenIncluder> includers)
	{
		_includers = includers;
	}

	public IEnumerable<IEmailConfirmationTokenIncluder> Create(ICollection<IdentityIncludeDescriptor> descriptors)
	{
		var includers = _includers.Where(s => descriptors.Any(p =>
														p.IncludeType == s.IncludeType &&
														p.DestinationType == s.DestinationType));

		return includers;
	}
}
