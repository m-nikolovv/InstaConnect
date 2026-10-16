namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationQueryIntegrationTest : BasePostLikeWebTest
{
	protected PostLikeController Controller { get; }

	protected UserPostLikeController UserController { get; }

	protected BasePostLikePresentationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetPostLikeController();
		UserController = ServiceScope.GetUserPostLikeController();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(Posts, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await OnInitializeAsync();
	}
}
