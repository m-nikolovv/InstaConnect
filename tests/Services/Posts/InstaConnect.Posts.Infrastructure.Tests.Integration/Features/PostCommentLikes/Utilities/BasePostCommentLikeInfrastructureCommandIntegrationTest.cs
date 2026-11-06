using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeInfrastructureCommandIntegrationTest : BasePostsCommandWebTest
{
	protected IPostCommentLikeCommandRepository Repository { get; }

	protected IPostCommentLikeIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostCommentLikeInfrastructureCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostCommentLikeCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetPostCommentLikeIncludeBuilderFactory();

	}
}
