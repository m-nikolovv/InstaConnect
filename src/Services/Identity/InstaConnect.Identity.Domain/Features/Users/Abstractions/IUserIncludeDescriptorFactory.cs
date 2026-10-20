namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;

public interface IUserIncludeDescriptorFactory
{
	public IdentityIncludeDescriptor CreateUserClaims();

	public IdentityIncludeDescriptor CreateRefreshTokens();

	public IdentityIncludeDescriptor CreateForgotPasswordTokens();

	public IdentityIncludeDescriptor CreateEmailConfirmationTokens();
}
