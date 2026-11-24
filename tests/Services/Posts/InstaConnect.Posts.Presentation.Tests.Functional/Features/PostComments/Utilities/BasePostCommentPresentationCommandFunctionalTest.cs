using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Extensions;
using InstaConnect.Posts.Tests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostComments.Utilities;

public abstract class BasePostCommentPresentationCommandFunctionalTest : BasePostCommentWebCommandTest
{
	protected IPostCacheHandler CacheHandler { get; }

	protected IPostCommentApiClient CommentApiClient { get; }

	protected IPostCommentEventClient CommentEventClient { get; }

	protected IPostCommentCacheHandler CommentCacheHandler { get; }

	protected BasePostCommentPresentationCommandFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		CacheHandler = ServiceScope.GetPostCacheHandler();
		CommentApiClient = webApplicationFactory.CreateCommentApiClient();
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
