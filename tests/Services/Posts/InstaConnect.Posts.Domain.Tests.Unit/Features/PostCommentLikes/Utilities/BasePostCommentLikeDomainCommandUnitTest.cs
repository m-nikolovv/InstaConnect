using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Posts.Domain.Features.Common.Extensions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeDomainCommandUnitTest : BasePostCommentLikeTest
{
	protected IApplicationMapper Mapper { get; }

	protected IEventPublisher EventPublisher { get; }

	protected IPostCommentLikeFactory Factory { get; }

	protected IPostCommandRepository Repository { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected IUserCommandRepository UserRepository { get; }

	protected IPostCommentCommandRepository CommentRepository { get; }

	protected IPostIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected IPostCommentLikeCommandRepository CommentLikeRepository { get; }

	protected IPostCommentIncludeBuilderFactory CommentIncludeBuilderFactory { get; }

	protected IPostCommentLikeIncludeBuilderFactory CommentLikeIncludeBuilderFactory { get; }

	protected BasePostCommentLikeDomainCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(PostsDomainReference.Assembly);
		EventPublisher = DomainMockFactory.CreateEventPublisher();
		Factory = PostCommentLikeDomainMockFactory.CreateFactory();
		Repository = PostDomainMockFactory.CreateCommandRepository();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		UserRepository = UserDomainMockFactory.CreateCommandRepository();
		CommentRepository = PostCommentDomainMockFactory.CreateCommandRepository();
		IncludeBuilderFactory = PostMockFactory.CreateIncludeBuilderFactory();
		CommentLikeRepository = PostCommentLikeDomainMockFactory.CreateCommandRepository();
		CommentIncludeBuilderFactory = PostCommentDomainMockFactory.CreateIncludeBuilderFactory();
		CommentLikeIncludeBuilderFactory = PostCommentLikeDomainMockFactory.CreateIncludeBuilderFactory();
	}
}
