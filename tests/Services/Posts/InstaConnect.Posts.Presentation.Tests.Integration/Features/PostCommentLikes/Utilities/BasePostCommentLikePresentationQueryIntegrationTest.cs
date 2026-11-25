using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Controllers.v1;

namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationQueryIntegrationTest : BasePostCommentLikeWebQueryTest
{
	protected PostCommentLikeController Controller { get; }

	protected UserPostCommentLikeController UserController { get; }

	protected IPostCommentLikeCacheHandler CommentLikeCacheHandler { get; }

	protected BasePostCommentLikePresentationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetPostCommentLikeController();
		UserController = ServiceScope.GetUserPostCommentLikeController();
		CommentLikeCacheHandler = ServiceScope.GetPostCommentLikeCacheHandler();
	}
}
