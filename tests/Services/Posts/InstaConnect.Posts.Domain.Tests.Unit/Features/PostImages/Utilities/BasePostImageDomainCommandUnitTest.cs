using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Domain.Tests.Features.Utilities;
using InstaConnect.Posts.Domain.Features.PostImages.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostImages.Utilities;

public abstract class BasePostImageDomainCommandUnitTest : BasePostImageTest
{
	protected IPostImageFactory Factory { get; }

	protected IGuidProvider GuidProvider { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected IPostImageCommandRepository Repository { get; }

	protected BasePostImageDomainCommandUnitTest()
	{
		Factory = PostImageDomainMockFactory.CreateFactory();
		GuidProvider = DomainMockFactory.CreateGuidProvider();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		Repository = PostImageDomainMockFactory.CreateCommandRepository();
	}
}
