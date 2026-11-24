using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Extensions;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentApplicationCommandIntegrationTest : BasePostCommentWebCommandTest
{
	protected IApplicationSender Sender { get; }

	protected IPostCacheHandler CacheHandler { get; }

	protected IPostCommentEventClient CommentEventClient { get; }

	protected IPostCommentCacheHandler CommentCacheHandler { get; }

	protected BasePostCommentApplicationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		CacheHandler = ServiceScope.GetPostCacheHandler();
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
