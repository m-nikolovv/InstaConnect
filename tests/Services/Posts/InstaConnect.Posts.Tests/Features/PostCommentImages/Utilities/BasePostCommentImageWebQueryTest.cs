namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

public abstract class BasePostCommentImageWebQueryTest : BasePostCommentImageWebTest
{
	protected BasePostCommentImageWebQueryTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(Posts, CancellationToken);
		await ServiceScope.AddRangeAsync(PostComments, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentImages, CancellationToken);
		await OnInitializeAsync();
	}
}
