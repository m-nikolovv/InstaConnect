using InstaConnect.Posts.Domain.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Posts.Utilities;

public abstract class BasePostInfrastructureQueryIntegrationTest : BasePostsWebQueryTest
{
	protected IPostQueryRepository Repository { get; }

	protected BasePostInfrastructureQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostQueryRepository();

	}
}
