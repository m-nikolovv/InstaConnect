using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikeDomainQueryIntegrationTest : BasePostLikeWebQueryTest
{
	protected IPostLikeQueryService Service { get; }

	protected IPostLikeCacheHandler LikeCacheHandler { get; }

	protected BasePostLikeDomainQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Service = ServiceScope.GetPostLikeQueryService();
		LikeCacheHandler = ServiceScope.GetPostLikeCacheHandler();
	}
}
