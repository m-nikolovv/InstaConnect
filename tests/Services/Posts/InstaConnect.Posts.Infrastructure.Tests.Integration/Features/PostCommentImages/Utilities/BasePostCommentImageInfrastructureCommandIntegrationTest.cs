using InstaConnect.Posts.Domain.Features.PostCommentImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentImages.Utilities;

public abstract class BasePostCommentImageInfrastructureCommandIntegrationTest : BasePostsWebCommandTest
{
	protected IPostCommentImageCommandRepository Repository { get; }

	protected BasePostCommentImageInfrastructureCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetPostCommentImageCommandRepository();
	}
}
