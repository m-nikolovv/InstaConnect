using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeDomainQueryIntegrationTest : BasePostCommentLikeWebQueryTest
{
	protected IPostCommentLikeQueryService Service { get; }

	protected BasePostCommentLikeDomainQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Service = ServiceScope.GetPostCommentLikeQueryService();
	}
}
