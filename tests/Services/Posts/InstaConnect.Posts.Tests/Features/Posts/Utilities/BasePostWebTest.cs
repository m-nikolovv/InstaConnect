namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public abstract class BasePostWebTest : BasePostTest, IClassFixture<PostsWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BasePostWebTest(PostsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
