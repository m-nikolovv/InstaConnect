using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikeInfrastructureCommandUnitTest : BasePostLikeTest
{
	protected IPostLikeFluent Fluent { get; }

	protected IPostLikeCollection Collection { get; }

	protected IPostLikeIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostLikeInfrastructureCommandUnitTest()
	{
		Fluent = PostLikeInfrastructureMockFactory.CreateFluent();
		Collection = PostLikeInfrastructureMockFactory.CreateCollection();
		IncludeBuilderFactory = PostLikeMockFactory.CreateIncludeBuilderFactory();
	}
}
