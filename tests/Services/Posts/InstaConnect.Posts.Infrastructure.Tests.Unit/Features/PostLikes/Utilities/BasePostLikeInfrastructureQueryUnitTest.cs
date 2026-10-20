using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikeInfrastructureQueryUnitTest : BasePostLikeTest
{
	protected IPostLikeFluent Fluent { get; }

	protected IPostLikeCollection Collection { get; }

	protected IPostLikeResponseFluent ResponseFluent { get; }

	protected IPostIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected IPostLikeIncludeBuilderFactory LikeIncludeBuilderFactory { get; }

	protected BasePostLikeInfrastructureQueryUnitTest()
	{
		Collection = PostLikeInfrastructureMockFactory.CreateCollection();
		Fluent = PostLikeInfrastructureMockFactory.CreateFluent();
		ResponseFluent = PostLikeInfrastructureMockFactory.CreateResponseFluent();
		IncludeBuilderFactory = PostMockFactory.CreateIncludeBuilderFactory();
		LikeIncludeBuilderFactory = PostLikeMockFactory.CreateIncludeBuilderFactory();
	}
}
