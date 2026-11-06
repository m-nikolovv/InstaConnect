using InstaConnect.Follows.Presentation.Features.Common.Extensions;
using InstaConnect.Follows.Tests.Features.Common.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Unit.Features.Follows.Utilities;

public abstract class BaseFollowPresentationQueryUnitTest : BaseFollowsQueryTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseFollowPresentationQueryUnitTest()
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(FollowsPresentationReference.Assembly);
	}
}
