using InstaConnect.Posts.Domain.Features.PostImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostImages.Utilities;

public abstract class BasePostImageInfrastructureCommandIntegrationTest : BasePostImageWebCommandTest
{
	protected IPostCacheHandler CacheHandler { get; }

	protected IPostImageCommandRepository Repository { get; }

	protected BasePostImageInfrastructureCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		CacheHandler = ServiceScope.GetPostCacheHandler();
		Repository = ServiceScope.GetPostImageCommandRepository();
	}
}
