using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Features.Common.Extensions;
using InstaConnect.Chats.Domain.Features.Users.Abstractions;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Domain.Tests.Features.Utilities;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Tests.Features.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.Chats.Utilities;

public abstract class BaseChatDomainCommandUnitTest : BaseChatTest
{
	protected IChatFactory Factory { get; }

	protected IApplicationMapper Mapper { get; }

	protected IEventPublisher EventPublisher { get; }

	protected IChatCommandRepository Repository { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected IUserCommandRepository UserRepository { get; }

	protected BaseChatDomainCommandUnitTest()
	{
		Factory = ChatDomainMockFactory.CreateFactory();
		Mapper = MockFactory.CreateMapper(ChatsDomainReference.Assembly);
		EventPublisher = DomainMockFactory.CreateEventPublisher();
		Repository = ChatDomainMockFactory.CreateCommandRepository();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		UserRepository = UserDomainMockFactory.CreateCommandRepository();
	}
}
