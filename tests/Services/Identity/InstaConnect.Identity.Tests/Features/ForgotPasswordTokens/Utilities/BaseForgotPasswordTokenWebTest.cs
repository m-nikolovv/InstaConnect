namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenWebTest : BaseForgotPasswordTokenTest, IClassFixture<IdentityWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseForgotPasswordTokenWebTest(IdentityWebApplicationFactory webApplicationFactory, bool isEmailConfirmed = true) : base(webApplicationFactory.Services.GetPasswordHasher(), isEmailConfirmed)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
