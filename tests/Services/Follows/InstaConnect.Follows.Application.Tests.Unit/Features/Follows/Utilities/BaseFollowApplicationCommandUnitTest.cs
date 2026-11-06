using InstaConnect.Follows.Application.Features.Common.Extensions;
using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Tests.Features.Common.Utilities;

namespace InstaConnect.Follows.Application.Tests.Unit.Features.Follows.Utilities;

public abstract class BaseFollowApplicationCommandUnitTest : BaseFollowsCommandTest
{
	protected IApplicationMapper Mapper { get; }

	protected IFollowCommandService Service { get; }

	protected BaseFollowApplicationCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(FollowsApplicationReference.Assembly);
		Service = FollowApplicationMockFactory.CreateCommandService();
	}
}
