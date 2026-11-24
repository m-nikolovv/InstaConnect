using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
using InstaConnect.Posts.Presentation.Features.PostComments.Controllers.v1;
using InstaConnect.Posts.Tests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentPresentationCommandIntegrationTest : BasePostCommentWebCommandTest
{
	protected IPostCacheHandler CacheHandler { get; }

	protected PostCommentController Controller { get; }

	protected IPostCommentEventClient CommentEventClient { get; }

	protected IPostCommentCacheHandler CommentCacheHandler { get; }

	protected BasePostCommentPresentationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		CacheHandler = ServiceScope.GetPostCacheHandler();
		Controller = ServiceScope.GetPostCommentController();
		CommentEventClient = webApplicationFactory.CreateCommentEventClient();
		CommentCacheHandler = ServiceScope.GetPostCommentCacheHandler();
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await CommentEventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await CommentEventClient.StopAsync(CancellationToken);
	}
}
