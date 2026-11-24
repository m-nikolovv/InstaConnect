using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentInfrastructureQueryIntegrationTest : BasePostCommentWebQueryTest
{
	protected IPostCommentQueryRepository Repository { get; }

	protected IPostCommentCacheHandler CommentCacheHandler { get; }

	protected BasePostCommentInfrastructureQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostCommentQueryRepository();
		CommentCacheHandler = ServiceScope.GetPostCommentCacheHandler();
	}
}
