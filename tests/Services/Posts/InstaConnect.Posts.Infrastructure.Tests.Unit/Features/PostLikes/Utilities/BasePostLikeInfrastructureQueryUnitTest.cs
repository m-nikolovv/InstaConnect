using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikeInfrastructureQueryUnitTest : BasePostLikeQueryTest
{
	protected IPostLikeFluent Fluent { get; }

	protected IPostLikeCollection Collection { get; }

	protected IPostLikeResponseFluent ResponseFluent { get; }

	protected IPostLikeCacheHandler LikeCacheHandler { get; }

	protected IPostIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected IPostLikeIncludeBuilderFactory LikeIncludeBuilderFactory { get; }

	protected BasePostLikeInfrastructureQueryUnitTest()
	{
		Fluent = PostLikeInfrastructureMockFactory.CreateFluent();
		Collection = PostLikeInfrastructureMockFactory.CreateCollection();
		ResponseFluent = PostLikeInfrastructureMockFactory.CreateResponseFluent();
		LikeCacheHandler = PostLikeInfrastructureMockFactory.CreateCacheHandler();
		IncludeBuilderFactory = PostMockFactory.CreateIncludeBuilderFactory();
		LikeIncludeBuilderFactory = PostLikeMockFactory.CreateIncludeBuilderFactory();
	}
}
