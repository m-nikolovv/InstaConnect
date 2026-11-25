using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeInfrastructureQueryIntegrationTest : BasePostCommentLikeWebQueryTest
{
	protected IPostCommentLikeQueryRepository Repository { get; }

	protected IPostCommentLikeCacheHandler CommentLikeCacheHandler { get; }

	protected BasePostCommentLikeInfrastructureQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostCommentLikeQueryRepository();
		CommentLikeCacheHandler = ServiceScope.GetPostCommentLikeCacheHandler();

	}
}
