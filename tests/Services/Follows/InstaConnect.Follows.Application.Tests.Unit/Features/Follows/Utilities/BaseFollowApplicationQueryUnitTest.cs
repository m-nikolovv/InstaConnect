using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Tests.Features.Utilities;
using InstaConnect.Follows.Application.Features.Common.Extensions;
using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Application.Tests.Unit.Features.Follows.Utilities;

public abstract class BaseFollowApplicationQueryUnitTest : BaseFollowTest
{
	protected IApplicationMapper Mapper { get; }

	protected IFollowQueryService Service { get; }

	protected BaseFollowApplicationQueryUnitTest()
	{
		Mapper = MockFactory.CreateMapper(FollowsApplicationReference.Assembly);
		Service = FollowApplicationMockFactory.CreateQueryService();
	}
}
