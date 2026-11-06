using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Common.Extensions;
using InstaConnect.Follows.Tests.Features.Common.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserInfrastructureEventHandlerUnitTest : BaseFollowsCommandTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseUserInfrastructureEventHandlerUnitTest()
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(FollowsInfrastructureReference.Assembly);
	}
}
