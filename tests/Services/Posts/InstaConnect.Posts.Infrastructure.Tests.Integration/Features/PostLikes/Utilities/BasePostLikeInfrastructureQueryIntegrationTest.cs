using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikeInfrastructureQueryIntegrationTest : BasePostsWebQueryTest
{
	protected IPostLikeQueryRepository Repository { get; }

	protected BasePostLikeInfrastructureQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostLikeQueryRepository();

	}
}
