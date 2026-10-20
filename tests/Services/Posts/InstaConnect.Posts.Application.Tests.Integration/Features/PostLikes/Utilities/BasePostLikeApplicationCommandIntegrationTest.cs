using InstaConnect.Posts.Tests.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostLikes.Extensions;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikeApplicationCommandIntegrationTest : BasePostLikeWebTest
{
	protected IApplicationSender Sender { get; }

	protected IPostLikeEventClient LikeEventClient { get; }

	protected BasePostLikeApplicationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
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
