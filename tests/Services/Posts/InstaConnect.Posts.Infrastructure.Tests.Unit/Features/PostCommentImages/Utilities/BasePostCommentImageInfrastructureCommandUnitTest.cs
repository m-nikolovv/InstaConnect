using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentImages.Utilities;

public abstract class BasePostCommentImageInfrastructureCommandUnitTest : BasePostCommentImageTest
{
	protected IPostCommentImageFluent Fluent { get; }

	protected IPostCommentImageCollection Collection { get; }

	protected BasePostCommentImageInfrastructureCommandUnitTest()
	{
		Fluent = PostCommentImageInfrastructureMockFactory.CreateFluent();
		Collection = PostCommentImageInfrastructureMockFactory.CreateCollection();
	}
}
