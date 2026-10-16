namespace InstaConnect.Posts.Domain.Tests.Features.PostImages.Utilities;

public static class PostImageDomainMockFactory
{
	public static IPostImageFactory CreateFactory()
	{
		return Mocker.Mock<IPostImageFactory>();
	}

	public static IPostImageCommandRepository CreateCommandRepository()
	{
		return Mocker.Mock<IPostImageCommandRepository>();
	}
}
