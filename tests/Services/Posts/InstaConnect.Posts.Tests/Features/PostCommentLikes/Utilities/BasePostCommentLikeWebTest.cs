namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeWebTest : BasePostCommentLikeTest, IClassFixture<PostsWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BasePostCommentLikeWebTest(PostsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
