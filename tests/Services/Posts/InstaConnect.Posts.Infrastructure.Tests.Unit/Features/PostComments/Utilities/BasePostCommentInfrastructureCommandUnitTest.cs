using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostComments.Utilities;

public abstract class BasePostCommentInfrastructureCommandUnitTest : BasePostCommentCommandTest
{
	protected IPostCommentFluent Fluent { get; }

	protected IPostCacheHandler CacheHandler { get; }

	protected IPostCommentCollection Collection { get; }

	protected IPostCommentCacheHandler CommentCacheHandler { get; }

	protected IPostCommentIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostCommentInfrastructureCommandUnitTest()
	{
		Fluent = PostCommentInfrastructureMockFactory.CreateFluent();
		CacheHandler = PostInfrastructureMockFactory.CreateCacheHandler();
		Collection = PostCommentInfrastructureMockFactory.CreateCollection();
		CommentCacheHandler = PostCommentInfrastructureMockFactory.CreateCacheHandler();
		IncludeBuilderFactory = PostCommentMockFactory.CreateIncludeBuilderFactory();
	}
}
