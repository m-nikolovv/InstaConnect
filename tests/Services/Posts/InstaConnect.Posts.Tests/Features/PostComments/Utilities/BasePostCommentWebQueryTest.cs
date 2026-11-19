namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public abstract class BasePostCommentWebQueryTest : BasePostCommentWebTest
{
	protected BasePostCommentWebQueryTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(Posts, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(PostLikes, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(PostComments, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentLikes, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentImages, CancellationToken);
		await OnInitializeAsync();
	}
}
