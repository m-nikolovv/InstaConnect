using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.Posts.Utilities;

public abstract class BasePostDomainQueryIntegrationTest : BasePostWebQueryTest
{
	protected IPostQueryService Service { get; }

	protected IPostCacheHandler CacheHandler { get; }

	protected BasePostDomainQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Service = ServiceScope.GetPostQueryService();
		CacheHandler = ServiceScope.GetPostCacheHandler();
	}
}
