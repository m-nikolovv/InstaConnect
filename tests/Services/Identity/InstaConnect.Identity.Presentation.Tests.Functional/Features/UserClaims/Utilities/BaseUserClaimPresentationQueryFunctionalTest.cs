using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.UserClaims.Utilities;

public abstract class BaseUserClaimPresentationQueryFunctionalTest : BaseUserClaimWebQueryTest
{
	protected IUserClaimApiClient ClaimApiClient { get; }

	protected BaseUserClaimPresentationQueryFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		ClaimApiClient = webApplicationFactory.CreateClaimApiClient();
	}
}
