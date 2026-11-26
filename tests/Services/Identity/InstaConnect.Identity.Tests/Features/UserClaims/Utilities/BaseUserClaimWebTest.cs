namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public abstract class BaseUserClaimWebTest : BaseUserClaimTest, IClassFixture<IdentityWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseUserClaimWebTest(IdentityWebApplicationFactory webApplicationFactory, bool isEmailConfirmed = true) : base(webApplicationFactory.Services.GetPasswordHasher(), isEmailConfirmed)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
