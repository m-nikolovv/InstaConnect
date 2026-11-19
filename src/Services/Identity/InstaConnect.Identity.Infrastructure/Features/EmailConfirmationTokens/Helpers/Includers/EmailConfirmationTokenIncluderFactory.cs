namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Includers;

internal class EmailConfirmationTokenIncluderFactory
	: IncluderFactory<IdentityIncludeType, IdentityDestinationType, IdentityIncludeDescriptor, IEmailConfirmationTokenIncluder, EmailConfirmationToken>, IEmailConfirmationTokenIncluderFactory
{
	public EmailConfirmationTokenIncluderFactory(IEnumerable<IEmailConfirmationTokenIncluder> includers) : base(includers)
	{
	}
}
