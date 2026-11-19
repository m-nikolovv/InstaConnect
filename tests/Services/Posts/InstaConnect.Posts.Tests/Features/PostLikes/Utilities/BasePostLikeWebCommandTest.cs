namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public abstract class BasePostLikeWebCommandTest : BasePostLikeWebTest
{
	protected BasePostLikeWebCommandTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CurrentUserId, CancellationToken);
		await ServiceScope.AddAsync(Post, CurrentUserId, CancellationToken);
		await OnInitializeAsync();
	}
}
