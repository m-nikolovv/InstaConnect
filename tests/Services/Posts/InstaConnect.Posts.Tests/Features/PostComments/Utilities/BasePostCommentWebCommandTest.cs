namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public abstract class BasePostCommentWebCommandTest : BasePostCommentWebTest
{
	protected BasePostCommentWebCommandTest(PostsWebApplicationFactory webApplicationFactory)
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
