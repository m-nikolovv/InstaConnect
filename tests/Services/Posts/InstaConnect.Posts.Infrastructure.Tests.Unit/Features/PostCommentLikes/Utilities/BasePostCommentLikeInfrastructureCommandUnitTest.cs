using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeInfrastructureCommandUnitTest : BasePostCommentLikeTest
{
	protected IPostCommentLikeFluent Fluent { get; }

	protected IPostCommentLikeCollection Collection { get; }

	protected IPostCommentLikeIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostCommentLikeInfrastructureCommandUnitTest()
	{
		Fluent = PostCommentLikeInfrastructureMockFactory.CreateFluent();
		Collection = PostCommentLikeInfrastructureMockFactory.CreateCollection();
		IncludeBuilderFactory = PostCommentLikeMockFactory.CreateIncludeBuilderFactory();
	}
}
