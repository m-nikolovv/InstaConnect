using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Posts.Domain.Features.PostComments.Helpers;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;

public static class PostCommentDomainMockFactory
{
	public static IPostCommentFactory CreateFactory()
	{
		return Mocker.Mock<IPostCommentFactory>();
	}

	public static IPostCommentCollectionResponseFactory CreateCollectionResponseFactory()
	{
		return new PostCommentCollectionResponseFactory(new Paginator());
	}

	public static IPostCommentIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new PostCommentIncludeBuilderFactory(new PostCommentIncludeDescriptorFactory());
	}

	public static IPostCommentCommandRepository CreateCommandRepository()
	{
		return Mocker.Mock<IPostCommentCommandRepository>();
	}

	public static IPostCommentQueryRepository CreateQueryRepository()
	{
		return Mocker.Mock<IPostCommentQueryRepository>();
	}
}
