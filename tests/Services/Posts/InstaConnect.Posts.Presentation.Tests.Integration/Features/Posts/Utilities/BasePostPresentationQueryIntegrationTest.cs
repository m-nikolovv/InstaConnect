namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.Posts.Utilities;

public abstract class BasePostPresentationQueryIntegrationTest : BasePostWebTest
{
	protected PostController Controller { get; }

	protected UserPostController UserController { get; }

	protected BasePostPresentationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetPostController();
		UserController = ServiceScope.GetUserPostController();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(PostLikes, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await OnInitializeAsync();
	}
}
