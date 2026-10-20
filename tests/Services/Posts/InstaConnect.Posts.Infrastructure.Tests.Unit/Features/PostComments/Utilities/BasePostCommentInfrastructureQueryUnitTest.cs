using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostComments.Utilities;

public abstract class BasePostCommentInfrastructureQueryUnitTest : BasePostCommentTest
{
	protected IPostCommentFluent Fluent { get; }

	protected IPostCommentCollection Collection { get; }

	protected IPostCommentResponseFluent ResponseFluent { get; }

	protected IPostIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected IPostCommentIncludeBuilderFactory CommentIncludeBuilderFactory { get; }

	protected BasePostCommentInfrastructureQueryUnitTest()
	{
		Collection = PostCommentInfrastructureMockFactory.CreateCollection();
		Fluent = PostCommentInfrastructureMockFactory.CreateFluent();
		ResponseFluent = PostCommentInfrastructureMockFactory.CreateResponseFluent();
		IncludeBuilderFactory = PostMockFactory.CreateIncludeBuilderFactory();
		CommentIncludeBuilderFactory = PostCommentMockFactory.CreateIncludeBuilderFactory();
	}
}
