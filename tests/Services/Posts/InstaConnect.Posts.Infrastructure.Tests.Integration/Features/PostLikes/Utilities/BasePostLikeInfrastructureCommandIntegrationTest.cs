using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikeInfrastructureCommandIntegrationTest : BasePostLikeWebCommandTest
{
	protected IPostCacheHandler CacheHandler { get; }

	protected IPostLikeCommandRepository Repository { get; }

	protected IPostLikeCacheHandler LikeCacheHandler { get; }

	protected IPostLikeIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostLikeInfrastructureCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		CacheHandler = ServiceScope.GetPostCacheHandler();
		Repository = ServiceScope.GetPostLikeCommandRepository();
		LikeCacheHandler = ServiceScope.GetPostLikeCacheHandler();
		IncludeBuilderFactory = ServiceScope.GetPostLikeIncludeBuilderFactory();

	}
}
