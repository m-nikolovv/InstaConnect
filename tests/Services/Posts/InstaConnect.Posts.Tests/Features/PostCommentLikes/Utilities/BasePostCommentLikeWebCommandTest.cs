namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeWebCommandTest : BasePostCommentLikeWebTest
{
	protected BasePostCommentLikeWebCommandTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(Post, CancellationToken);
		await ServiceScope.AddAsync(PostComment, CancellationToken);
		await OnInitializeAsync();
	}
}
