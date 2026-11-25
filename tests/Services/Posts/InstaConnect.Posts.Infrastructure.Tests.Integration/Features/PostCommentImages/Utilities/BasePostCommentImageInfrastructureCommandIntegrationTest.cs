using InstaConnect.Posts.Domain.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentImages.Utilities;

public abstract class BasePostCommentImageInfrastructureCommandIntegrationTest : BasePostCommentImageWebCommandTest
{
	protected IPostCommentCacheHandler CommentCacheHandler { get; }

	protected IPostCommentImageCommandRepository Repository { get; }

	protected BasePostCommentImageInfrastructureCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		CommentCacheHandler = ServiceScope.GetPostCommentCacheHandler();
		Repository = ServiceScope.GetPostCommentImageCommandRepository();
	}
}
