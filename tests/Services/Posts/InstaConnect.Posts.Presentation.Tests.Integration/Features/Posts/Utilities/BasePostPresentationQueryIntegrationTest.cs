using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
using InstaConnect.Posts.Presentation.Features.Posts.Controllers.v1;

namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.Posts.Utilities;

public abstract class BasePostPresentationQueryIntegrationTest : BasePostWebQueryTest
{
	protected PostController Controller { get; }

	protected IPostCacheHandler CacheHandler { get; }

	protected UserPostController UserController { get; }

	protected BasePostPresentationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetPostController();
		CacheHandler = ServiceScope.GetPostCacheHandler();
		UserController = ServiceScope.GetUserPostController();
	}
}
