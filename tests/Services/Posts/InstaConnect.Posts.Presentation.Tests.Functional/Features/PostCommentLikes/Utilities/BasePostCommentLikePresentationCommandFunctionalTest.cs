using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationCommandFunctionalTest : BasePostCommentLikeWebCommandTest
{
	protected IPostCommentCacheHandler CommentCacheHandler { get; }

	protected IPostCommentLikeApiClient CommentLikeApiClient { get; }

	protected IPostCommentLikeEventClient CommentLikeEventClient { get; }

	protected IPostCommentLikeCacheHandler CommentLikeCacheHandler { get; }

	protected BasePostCommentLikePresentationCommandFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		CommentCacheHandler = ServiceScope.GetPostCommentCacheHandler();
		CommentLikeApiClient = webApplicationFactory.CreateCommentLikeApiClient();
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
