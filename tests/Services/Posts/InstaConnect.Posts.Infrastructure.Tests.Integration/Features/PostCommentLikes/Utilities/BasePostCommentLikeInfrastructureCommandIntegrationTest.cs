using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeInfrastructureCommandIntegrationTest : BasePostCommentLikeWebCommandTest
{
	protected IPostCommentLikeCommandRepository Repository { get; }

	protected IPostCommentCacheHandler CommentCacheHandler { get; }

	protected IPostCommentLikeCacheHandler CommentLikeCacheHandler { get; }

	protected IPostCommentLikeIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostCommentLikeInfrastructureCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostCommentLikeCommandRepository();
		CommentCacheHandler = ServiceScope.GetPostCommentCacheHandler();
		CommentLikeCacheHandler = ServiceScope.GetPostCommentLikeCacheHandler();
		IncludeBuilderFactory = ServiceScope.GetPostCommentLikeIncludeBuilderFactory();

	}
}
