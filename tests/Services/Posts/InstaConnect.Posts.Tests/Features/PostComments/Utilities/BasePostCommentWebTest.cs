namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public abstract class BasePostCommentWebTest : BasePostCommentTest, IClassFixture<PostsWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BasePostCommentWebTest(PostsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
