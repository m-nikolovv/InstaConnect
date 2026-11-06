namespace InstaConnect.Identity.Tests.Features.Common.Utilities;

public abstract class BaseIdentityWebTest : BaseIdentityTest, IClassFixture<IdentityWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseIdentityWebTest(IdentityWebApplicationFactory webApplicationFactory, bool isEmailConfirmed = true) : base(webApplicationFactory.Services.GetPasswordHasher(), isEmailConfirmed)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
