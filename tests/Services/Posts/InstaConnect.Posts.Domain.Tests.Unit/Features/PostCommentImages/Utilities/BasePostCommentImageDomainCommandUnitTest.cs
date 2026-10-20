using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentImages.Utilities;

public abstract class BasePostCommentImageDomainCommandUnitTest : BasePostCommentImageTest
{
	protected IGuidProvider GuidProvider { get; }

	protected IPostCommentImageFactory Factory { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected IPostCommentImageCommandRepository Repository { get; }

	protected BasePostCommentImageDomainCommandUnitTest()
	{
		GuidProvider = DomainMockFactory.CreateGuidProvider();
		Factory = PostCommentImageDomainMockFactory.CreateFactory();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		Repository = PostCommentImageDomainMockFactory.CreateCommandRepository();
	}
}
