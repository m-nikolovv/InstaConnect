namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Includers;

internal class ForgotPasswordTokenIncluderFactory : IForgotPasswordTokenIncluderFactory
{
	private readonly IEnumerable<IForgotPasswordTokenIncluder> _includers;

	public ForgotPasswordTokenIncluderFactory(IEnumerable<IForgotPasswordTokenIncluder> includers)
	{
		_includers = includers;
	}

	public IEnumerable<IForgotPasswordTokenIncluder> Create(ICollection<IdentityIncludeDescriptor> descriptors)
	{
		var includers = _includers.Where(s => descriptors.Any(p =>
														p.IncludeType == s.IncludeType &&
														p.DestinationType == s.DestinationType));

		return includers;
	}
}
