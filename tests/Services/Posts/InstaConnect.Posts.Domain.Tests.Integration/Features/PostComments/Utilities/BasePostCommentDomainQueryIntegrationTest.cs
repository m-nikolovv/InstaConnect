using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentDomainQueryIntegrationTest : BasePostCommentWebQueryTest
{
	protected IPostCommentQueryService Service { get; }

	protected IPostCommentCacheHandler CommentCacheHandler { get; }

	protected BasePostCommentDomainQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Service = ServiceScope.GetPostCommentQueryService();
		CommentCacheHandler = ServiceScope.GetPostCommentCacheHandler();
	}
}
