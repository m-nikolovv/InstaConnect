using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostLikes.Extensions;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikeDomainCommandIntegrationTest : BasePostsWebCommandTest
{
	protected IPostLikeCommandService Service { get; }

	protected IPostLikeEventClient LikeEventClient { get; }

	protected BasePostLikeDomainCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Service = ServiceScope.GetPostLikeCommandService();
		LikeEventClient = webApplicationFactory.CreateLikeEventClient();
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await LikeEventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await LikeEventClient.StopAsync(CancellationToken);
	}
}
