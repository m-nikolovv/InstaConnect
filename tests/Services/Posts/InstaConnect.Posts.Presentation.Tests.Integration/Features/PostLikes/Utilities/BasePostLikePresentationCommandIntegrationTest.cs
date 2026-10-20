using InstaConnect.Posts.Presentation.Features.PostLikes.Controllers.v1;
using InstaConnect.Posts.Tests.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostLikes.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationCommandIntegrationTest : BasePostLikeWebTest
{
	protected PostLikeController Controller { get; }

	protected IPostLikeEventClient LikeEventClient { get; }

	protected BasePostLikePresentationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetPostLikeController();
		LikeEventClient = webApplicationFactory.CreateLikeEventClient();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(Post, CancellationToken);
		await OnInitializeAsync();
		await LikeEventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await LikeEventClient.StopAsync(CancellationToken);
	}
}
