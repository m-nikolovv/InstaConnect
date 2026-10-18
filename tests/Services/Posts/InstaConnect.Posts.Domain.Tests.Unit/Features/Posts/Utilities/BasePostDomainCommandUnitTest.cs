using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Domain.Tests.Features.Utilities;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Posts.Domain.Features.Common.Extensions;
using InstaConnect.Posts.Domain.Features.PostImages.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Utilities;

public abstract class BasePostDomainCommandUnitTest : BasePostTest
{
	protected IPostFactory Factory { get; }

	protected IApplicationMapper Mapper { get; }

	protected IGuidProvider GuidProvider { get; }

	protected IPostSummarizer Summarizer { get; }

	protected IImageHandler ImageHandler { get; }

	protected IEventPublisher EventPublisher { get; }

	protected IPostImageFactory ImageFactory { get; }

	protected IPostCommandRepository Repository { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected IUserCommandRepository UserRepository { get; }

	protected IPostImageCommandRepository ImageRepository { get; }

	protected IPostIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostDomainCommandUnitTest()
	{
		Factory = PostDomainMockFactory.CreateFactory();
		Mapper = MockFactory.CreateMapper(PostsDomainReference.Assembly);
		GuidProvider = DomainMockFactory.CreateGuidProvider();
		Summarizer = PostMockFactory.CreateSummarizer();
		ImageHandler = MockFactory.CreateImageHandler();
		EventPublisher = DomainMockFactory.CreateEventPublisher();
		ImageFactory = PostImageDomainMockFactory.CreateFactory();
		Repository = PostDomainMockFactory.CreateCommandRepository();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		UserRepository = UserDomainMockFactory.CreateCommandRepository();
		ImageRepository = PostImageDomainMockFactory.CreateCommandRepository();
		IncludeBuilderFactory = PostMockFactory.CreateIncludeBuilderFactory();
	}
}
