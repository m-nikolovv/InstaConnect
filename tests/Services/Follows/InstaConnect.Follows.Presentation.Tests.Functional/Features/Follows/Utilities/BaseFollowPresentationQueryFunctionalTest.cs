using InstaConnect.Follows.Presentation.Tests.Features.Follows.Abstractions;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Extensions;

namespace InstaConnect.Follows.Presentation.Tests.Functional.Features.Follows.Utilities;

public abstract class BaseFollowPresentationQueryFunctionalTest : BaseFollowsWebQueryTest
{
	protected IFollowApiClient ApiClient { get; }

	protected BaseFollowPresentationQueryFunctionalTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		ApiClient = webApplicationFactory.CreateApiClient();
	}
}
