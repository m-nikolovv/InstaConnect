namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public abstract class BasePostLikeWebQueryTest : BasePostLikeWebTest
{
	protected BasePostLikeWebQueryTest(PostsWebApplicationFactory webApplicationFactory)
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
		await OnInitializeAsync();
	}
}
