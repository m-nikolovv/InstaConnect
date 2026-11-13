namespace InstaConnect.Identity.Application.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimApplicationQueryIntegrationTest : BaseUserClaimWebQueryTest
{
	protected IApplicationSender Sender { get; }

	protected BaseUserClaimApplicationQueryIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}
}
