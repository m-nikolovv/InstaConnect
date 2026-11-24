using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Extensions;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentDomainCommandIntegrationTest : BasePostCommentWebCommandTest
{
	protected IPostCacheHandler CacheHandler { get; }

	protected IPostCommentCommandService Service { get; }

	protected IPostCommentEventClient CommentEventClient { get; }

	protected IPostCommentCacheHandler CommentCacheHandler { get; }

	protected BasePostCommentDomainCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		CacheHandler = ServiceScope.GetPostCacheHandler();
		Service = ServiceScope.GetPostCommentCommandService();
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
