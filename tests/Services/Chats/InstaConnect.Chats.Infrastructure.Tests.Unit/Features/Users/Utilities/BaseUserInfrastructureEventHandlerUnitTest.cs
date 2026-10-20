using InstaConnect.Chats.Infrastructure.Features.Common.Extensions;
using InstaConnect.Chats.Tests.Features.Users.Utilities;
using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserInfrastructureEventHandlerUnitTest : BaseUserTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseUserInfrastructureEventHandlerUnitTest()
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(ChatsInfrastructureReference.Assembly);
	}
}
