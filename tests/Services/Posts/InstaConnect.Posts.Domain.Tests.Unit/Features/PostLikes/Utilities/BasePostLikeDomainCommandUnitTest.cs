using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Posts.Domain.Features.Common.Extensions;
using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikeDomainCommandUnitTest : BasePostLikeTest
{
	protected IPostLikeFactory Factory { get; }

	protected IApplicationMapper Mapper { get; }

	protected IEventPublisher EventPublisher { get; }

	protected IPostCommandRepository Repository { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected IUserCommandRepository UserRepository { get; }

	protected IPostLikeCommandRepository LikeRepository { get; }

	protected IPostIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected IPostLikeIncludeBuilderFactory LikeIncludeBuilderFactory { get; }

	protected BasePostLikeDomainCommandUnitTest()
	{
		Factory = PostLikeDomainMockFactory.CreateFactory();
		Mapper = MockFactory.CreateMapper(PostsDomainReference.Assembly);
		EventPublisher = DomainMockFactory.CreateEventPublisher();
		Repository = PostDomainMockFactory.CreateCommandRepository();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		UserRepository = UserDomainMockFactory.CreateCommandRepository();
		LikeRepository = PostLikeDomainMockFactory.CreateCommandRepository();
		IncludeBuilderFactory = PostMockFactory.CreateIncludeBuilderFactory();
		LikeIncludeBuilderFactory = PostLikeDomainMockFactory.CreateIncludeBuilderFactory();
	}
}
