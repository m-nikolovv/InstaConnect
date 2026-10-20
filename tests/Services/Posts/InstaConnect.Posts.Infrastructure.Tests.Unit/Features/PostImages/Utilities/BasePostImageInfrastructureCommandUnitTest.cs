using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostImages.Utilities;

public abstract class BasePostImageInfrastructureCommandUnitTest : BasePostImageTest
{
	protected IPostImageFluent Fluent { get; }

	protected IPostImageCollection Collection { get; }

	protected BasePostImageInfrastructureCommandUnitTest()
	{
		Fluent = PostImageInfrastructureMockFactory.CreateFluent();
		Collection = PostImageInfrastructureMockFactory.CreateCollection();
	}
}
