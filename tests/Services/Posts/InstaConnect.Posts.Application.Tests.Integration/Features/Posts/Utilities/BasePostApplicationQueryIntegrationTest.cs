using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.Posts.Utilities;

public abstract class BasePostApplicationQueryIntegrationTest : BasePostWebQueryTest
{
	protected IApplicationSender Sender { get; }

	protected IPostCacheHandler CacheHandler { get; }

	protected BasePostApplicationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		CacheHandler = ServiceScope.GetPostCacheHandler();
	}
}
