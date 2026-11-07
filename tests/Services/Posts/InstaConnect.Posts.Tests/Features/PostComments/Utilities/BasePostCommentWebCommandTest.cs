namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public abstract class BasePostCommentWebCommandTest : BasePostCommentWebTest
{
	protected BasePostCommentWebCommandTest(PostsWebApplicationFactory webApplicationFactory)
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
