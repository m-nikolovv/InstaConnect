using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Domain.Tests.Features.Utilities;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Posts.Domain.Features.Common.Extensions;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Utilities;

public abstract class BasePostCommentDomainCommandUnitTest : BasePostCommentTest
{
	protected IApplicationMapper Mapper { get; }

	protected IGuidProvider GuidProvider { get; }

	protected IImageHandler ImageHandler { get; }

	protected IPostCommentFactory Factory { get; }

	protected IEventPublisher EventPublisher { get; }

	protected IPostCommandRepository Repository { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected IUserCommandRepository UserRepository { get; }

	protected IPostCommentSummarizer CommentSummarizer { get; }

	protected IPostCommentImageFactory CommentImageFactory { get; }

	protected IPostCommentCommandRepository CommentRepository { get; }

	protected IPostIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected IPostCommentImageCommandRepository CommentImageRepository { get; }

	protected IPostCommentIncludeBuilderFactory CommentIncludeBuilderFactory { get; }

	protected BasePostCommentDomainCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(PostsDomainReference.Assembly);
		GuidProvider = DomainMockFactory.CreateGuidProvider();
		ImageHandler = MockFactory.CreateImageHandler();
		Factory = PostCommentDomainMockFactory.CreateFactory();
		EventPublisher = DomainMockFactory.CreateEventPublisher();
		Repository = PostDomainMockFactory.CreateCommandRepository();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		UserRepository = UserDomainMockFactory.CreateCommandRepository();
		CommentSummarizer = PostCommentMockFactory.CreateSummarizer();
		CommentImageFactory = PostCommentImageDomainMockFactory.CreateFactory();
		CommentRepository = PostCommentDomainMockFactory.CreateCommandRepository();
		IncludeBuilderFactory = PostMockFactory.CreateIncludeBuilderFactory();
		CommentImageRepository = PostCommentImageDomainMockFactory.CreateCommandRepository();
		CommentIncludeBuilderFactory = PostCommentDomainMockFactory.CreateIncludeBuilderFactory();
	}
}
