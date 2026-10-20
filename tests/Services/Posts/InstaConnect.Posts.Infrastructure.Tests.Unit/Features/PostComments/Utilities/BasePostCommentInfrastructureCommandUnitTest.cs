using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostComments.Utilities;

public abstract class BasePostCommentInfrastructureCommandUnitTest : BasePostCommentTest
{
	protected IPostCommentFluent Fluent { get; }

	protected IPostCommentCollection Collection { get; }

	protected IPostCommentIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostCommentInfrastructureCommandUnitTest()
	{
		Fluent = PostCommentInfrastructureMockFactory.CreateFluent();
		Collection = PostCommentInfrastructureMockFactory.CreateCollection();
		IncludeBuilderFactory = PostCommentMockFactory.CreateIncludeBuilderFactory();
	}
}
