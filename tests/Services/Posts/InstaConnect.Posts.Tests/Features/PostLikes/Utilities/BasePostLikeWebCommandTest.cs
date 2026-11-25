namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public abstract class BasePostLikeWebCommandTest : BasePostLikeWebTest
{
	protected BasePostLikeWebCommandTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(Post, CancellationToken);
		await OnInitializeAsync();
	}
}
