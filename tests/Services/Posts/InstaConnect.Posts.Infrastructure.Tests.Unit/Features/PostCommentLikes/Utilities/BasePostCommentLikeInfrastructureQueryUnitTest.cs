using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeInfrastructureQueryUnitTest : BasePostCommentLikeQueryTest
{
	protected IPostCommentLikeFluent Fluent { get; }

	protected IPostCommentLikeCollection Collection { get; }

	protected IPostCommentLikeResponseFluent ResponseFluent { get; }

	protected IPostIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected IPostCommentLikeCacheHandler CommentLikeCacheHandler { get; }

	protected IPostCommentIncludeBuilderFactory CommentIncludeBuilderFactory { get; }

	protected IPostCommentLikeIncludeBuilderFactory CommentLikeIncludeBuilderFactory { get; }

	protected BasePostCommentLikeInfrastructureQueryUnitTest()
	{
		Fluent = PostCommentLikeInfrastructureMockFactory.CreateFluent();
		Collection = PostCommentLikeInfrastructureMockFactory.CreateCollection();
		ResponseFluent = PostCommentLikeInfrastructureMockFactory.CreateResponseFluent();
		IncludeBuilderFactory = PostMockFactory.CreateIncludeBuilderFactory();
		CommentLikeCacheHandler = PostCommentLikeInfrastructureMockFactory.CreateCacheHandler();
		CommentIncludeBuilderFactory = PostCommentMockFactory.CreateIncludeBuilderFactory();
		CommentLikeIncludeBuilderFactory = PostCommentLikeMockFactory.CreateIncludeBuilderFactory();
	}
}
