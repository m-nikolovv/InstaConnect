using InstaConnect.Identity.Presentation.Tests.Features.Users.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.Users.Utilities;

public abstract class BaseUserPresentationQueryFunctionalTest : BaseUserWebQueryTest
{
	protected IUserApiClient ApiClient { get; }

	protected BaseUserPresentationQueryFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		ApiClient = webApplicationFactory.CreateApiClient();
	}
}
