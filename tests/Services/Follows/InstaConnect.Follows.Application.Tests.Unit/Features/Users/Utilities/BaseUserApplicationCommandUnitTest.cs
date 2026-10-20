using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Tests.Features.Utilities;
using InstaConnect.Follows.Application.Features.Common.Extensions;
using InstaConnect.Follows.Application.Tests.Features.Users.Utilities;
using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Application.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserApplicationCommandUnitTest : BaseUserTest
{
	protected IApplicationMapper Mapper { get; }

	protected IUserCommandService UserService { get; }

	protected BaseUserApplicationCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(FollowsApplicationReference.Assembly);
		UserService = UserApplicationMockFactory.CreateCommandService();
	}
}
