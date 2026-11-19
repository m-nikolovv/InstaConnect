using InstaConnect.Posts.Presentation.Tests.Features.Posts.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.Posts.Utilities;

public abstract class BasePostPresentationQueryFunctionalTest : BasePostWebQueryTest
{
	protected IPostApiClient ApiClient { get; }

	protected BasePostPresentationQueryFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		ApiClient = webApplicationFactory.CreateApiClient();
	}
}
