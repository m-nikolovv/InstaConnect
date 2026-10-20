using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Utilities;

public static class PostImageInfrastructureMockFactory
{
	public static IPostImageCollection CreateCollection()
	{
		return Mocker.Mock<IPostImageCollection>();
	}

	public static IPostImageFluent CreateFluent()
	{
		return Mocker.Mock<IPostImageFluent>();
	}
}
