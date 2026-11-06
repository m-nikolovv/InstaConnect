using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentInfrastructureCommandIntegrationTest : BasePostsCommandWebTest
{
	protected IPostCommentCommandRepository Repository { get; }

	protected IPostCommentIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostCommentInfrastructureCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostCommentCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetPostCommentIncludeBuilderFactory();

	}
}
