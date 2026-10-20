using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Follows.Domain.Features.Common.Extensions;
using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Utilities;

public abstract class BaseFollowDomainCommandUnitTest : BaseFollowTest
{
	protected IFollowFactory Factory { get; }

	protected IApplicationMapper Mapper { get; }

	protected IEventPublisher EventPublisher { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected IFollowCommandRepository Repository { get; }

	protected IUserCommandRepository UserRepository { get; }

	protected IFollowNotificationService NotificationService { get; }

	protected IFollowIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseFollowDomainCommandUnitTest()
	{
		Factory = FollowDomainMockFactory.CreateFactory();
		Mapper = MockFactory.CreateMapper(FollowsDomainReference.Assembly);
		EventPublisher = DomainMockFactory.CreateEventPublisher();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		Repository = FollowDomainMockFactory.CreateCommandRepository();
		UserRepository = UserDomainMockFactory.CreateCommandRepository();
		NotificationService = FollowDomainMockFactory.CreateNotificationService();
		IncludeBuilderFactory = FollowMockFactory.CreateIncludeBuilderFactory();
	}
}
