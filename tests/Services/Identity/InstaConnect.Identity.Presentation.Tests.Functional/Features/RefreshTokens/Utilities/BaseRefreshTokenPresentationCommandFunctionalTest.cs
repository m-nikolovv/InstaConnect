using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenPresentationCommandFunctionalTest : BaseIdentityCommandWebTest
{
	protected IRefreshTokenApiClient RefreshTokenApiClient { get; }

	protected BaseRefreshTokenPresentationCommandFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		RefreshTokenApiClient = webApplicationFactory.CreateRefreshTokenApiClient();
	}
}
