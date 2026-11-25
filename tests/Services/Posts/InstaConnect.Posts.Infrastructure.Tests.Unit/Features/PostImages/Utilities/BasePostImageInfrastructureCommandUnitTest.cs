using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostImages.Utilities;

public abstract class BasePostImageInfrastructureCommandUnitTest : BasePostImageCommandTest
{
	protected IPostImageFluent Fluent { get; }

	protected IPostCacheHandler CacheHandler { get; }

	protected IPostImageCollection Collection { get; }

	protected IPostImageCacheHandler ImageCacheHandler { get; }

	protected BasePostImageInfrastructureCommandUnitTest()
	{
		Fluent = PostImageInfrastructureMockFactory.CreateFluent();
		CacheHandler = PostInfrastructureMockFactory.CreateCacheHandler();
		Collection = PostImageInfrastructureMockFactory.CreateCollection();
		ImageCacheHandler = PostImageInfrastructureMockFactory.CreateCacheHandler();
	}
}
