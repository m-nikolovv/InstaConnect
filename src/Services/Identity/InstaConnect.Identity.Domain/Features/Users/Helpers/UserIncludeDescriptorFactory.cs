namespace InstaConnect.Identity.Domain.Features.Users.Helpers;

public class UserIncludeDescriptorFactory : IUserIncludeDescriptorFactory
{
	public IdentityIncludeDescriptor CreateUserClaims()
	{
		return new(IdentityDestinationType.User, IdentityIncludeType.UserClaim);
	}

	public IdentityIncludeDescriptor CreateRefreshTokens()
	{
		return new(IdentityDestinationType.User, IdentityIncludeType.RefreshToken);
	}

	public IdentityIncludeDescriptor CreateForgotPasswordTokens()
	{
		return new(IdentityDestinationType.User, IdentityIncludeType.ForgotPasswordToken);
	}

	public IdentityIncludeDescriptor CreateEmailConfirmationTokens()
	{
		return new(IdentityDestinationType.User, IdentityIncludeType.EmailConfirmationToken);
	}
}
