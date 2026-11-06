namespace InstaConnect.Posts.Tests.Features.Common.Utilities;

public abstract class BasePostsWebTest : BasePostsTest, IClassFixture<PostsWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BasePostsWebTest(PostsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
