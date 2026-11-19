namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

public abstract class BasePostCommentImageWebQueryTest : BasePostCommentImageWebTest
{
	protected BasePostCommentImageWebQueryTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(Posts, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(PostComments, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentImages, CancellationToken);
		await OnInitializeAsync();
	}
}
