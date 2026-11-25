using InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Extensions;
using InstaConnect.Posts.Tests.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostLikes.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationCommandFunctionalTest : BasePostLikeWebCommandTest
{
	protected IPostCacheHandler CacheHandler { get; }

	protected IPostLikeApiClient LikeApiClient { get; }

	protected IPostLikeEventClient LikeEventClient { get; }

	protected IPostLikeCacheHandler LikeCacheHandler { get; }

	protected BasePostLikePresentationCommandFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		CacheHandler = ServiceScope.GetPostCacheHandler();
		LikeApiClient = webApplicationFactory.CreateLikeApiClient();
		LikeEventClient = webApplicationFactory.CreateLikeEventClient();
		LikeCacheHandler = ServiceScope.GetPostLikeCacheHandler();
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
