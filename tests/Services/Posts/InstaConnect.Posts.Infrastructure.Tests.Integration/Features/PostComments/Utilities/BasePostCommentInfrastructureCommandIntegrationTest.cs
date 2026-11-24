using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentInfrastructureCommandIntegrationTest : BasePostCommentWebCommandTest
{
	protected IPostCacheHandler CacheHandler { get; }

	protected IPostCommentCommandRepository Repository { get; }

	protected IPostCommentCacheHandler CommentCacheHandler { get; }

	protected IPostCommentIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostCommentInfrastructureCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		CacheHandler = ServiceScope.GetPostCacheHandler();
		Repository = ServiceScope.GetPostCommentCommandRepository();
		CommentCacheHandler = ServiceScope.GetPostCommentCacheHandler();
		IncludeBuilderFactory = ServiceScope.GetPostCommentIncludeBuilderFactory();
	}
}
