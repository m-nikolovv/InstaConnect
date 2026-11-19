namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public abstract class BaseUserWebTest : BaseUserTest, IClassFixture<IdentityWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseUserWebTest(IdentityWebApplicationFactory webApplicationFactory, bool isEmailConfirmed = true) : base(webApplicationFactory.Services.GetPasswordHasher(), isEmailConfirmed)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
