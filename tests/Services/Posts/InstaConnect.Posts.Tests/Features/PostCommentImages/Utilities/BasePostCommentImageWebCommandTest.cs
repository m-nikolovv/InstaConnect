namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

public abstract class BasePostCommentImageWebCommandTest : BasePostCommentImageWebTest
{
	protected BasePostCommentImageWebCommandTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CurrentUserId, CancellationToken);
		await ServiceScope.AddAsync(Post, CurrentUserId, CancellationToken);
		await ServiceScope.AddAsync(PostComment, CurrentUserId, CancellationToken);
		await OnInitializeAsync();
	}
}
