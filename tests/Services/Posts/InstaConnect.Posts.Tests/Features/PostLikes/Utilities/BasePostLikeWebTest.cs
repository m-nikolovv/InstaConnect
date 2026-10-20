namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public abstract class BasePostLikeWebTest : BasePostLikeTest, IClassFixture<PostsWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BasePostLikeWebTest(PostsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
