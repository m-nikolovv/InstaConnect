namespace InstaConnect.Posts.Tests.Features.PostImages.Utilities;

public abstract class BasePostImageWebCommandTest : BasePostImageWebTest
{
	protected BasePostImageWebCommandTest(PostsWebApplicationFactory webApplicationFactory)
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
