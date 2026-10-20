namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public abstract class BaseUserClaimWebTest : BaseUserClaimTest, IClassFixture<IdentityWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseUserClaimWebTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory.Services.GetPasswordHasher())
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
