namespace InstaConnect.Identity.Application.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimApplicationQueryIntegrationTest : BaseIdentityWebQueryTest
{
	protected IApplicationSender Sender { get; }

	protected BaseUserClaimApplicationQueryIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}
}
