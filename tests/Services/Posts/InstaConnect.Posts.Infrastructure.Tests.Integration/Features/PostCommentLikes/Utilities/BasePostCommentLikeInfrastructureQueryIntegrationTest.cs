using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeInfrastructureQueryIntegrationTest : BasePostsWebQueryTest
{
	protected IPostCommentLikeQueryRepository Repository { get; }

	protected BasePostCommentLikeInfrastructureQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostCommentLikeQueryRepository();

	}
}
