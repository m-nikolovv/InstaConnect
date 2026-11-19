namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Includers;

internal class ForgotPasswordTokenIncluderFactory
	: IncluderFactory<IdentityIncludeType, IdentityDestinationType, IdentityIncludeDescriptor, IForgotPasswordTokenIncluder, ForgotPasswordToken>, IForgotPasswordTokenIncluderFactory
{
	public ForgotPasswordTokenIncluderFactory(IEnumerable<IForgotPasswordTokenIncluder> includers) : base(includers)
	{
	}
}
