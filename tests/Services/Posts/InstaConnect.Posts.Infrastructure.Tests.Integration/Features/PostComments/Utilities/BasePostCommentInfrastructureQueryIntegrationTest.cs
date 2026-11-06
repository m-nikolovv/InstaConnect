using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentInfrastructureQueryIntegrationTest : BasePostsQueryWebTest
{
	protected IPostCommentQueryRepository Repository { get; }

	protected BasePostCommentInfrastructureQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostCommentQueryRepository();

	}
}
