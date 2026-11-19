namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeWebQueryTest : BasePostCommentLikeWebTest
{
	protected BasePostCommentLikeWebQueryTest(PostsWebApplicationFactory webApplicationFactory)
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
