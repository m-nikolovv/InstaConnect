using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Controllers.v1;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationCommandIntegrationTest : BasePostCommentLikeWebCommandTest
{
	protected PostCommentLikeController Controller { get; }

	protected IPostCommentCacheHandler CommentCacheHandler { get; }

	protected IPostCommentLikeEventClient CommentLikeEventClient { get; }

	protected IPostCommentLikeCacheHandler CommentLikeCacheHandler { get; }

	protected BasePostCommentLikePresentationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetPostCommentLikeController();
		CommentCacheHandler = ServiceScope.GetPostCommentCacheHandler();
		CommentLikeEventClient = webApplicationFactory.CreateCommentLikeEventClient();
		CommentLikeCacheHandler = ServiceScope.GetPostCommentLikeCacheHandler();
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await CommentLikeEventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await CommentLikeEventClient.StopAsync(CancellationToken);
	}
}
