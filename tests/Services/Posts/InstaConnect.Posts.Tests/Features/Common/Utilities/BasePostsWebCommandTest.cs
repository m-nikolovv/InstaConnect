namespace InstaConnect.Posts.Tests.Features.Common.Utilities;

public abstract class BasePostsWebCommandTest : BasePostsCommandTest, IClassFixture<PostsWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BasePostsWebCommandTest(PostsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(Posts, CancellationToken);
		await ServiceScope.AddRangeAsync(PostLikes, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await ServiceScope.AddRangeAsync(PostComments, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentImages, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentLikes, CancellationToken);
		await OnInitializeAsync();
	}
}
