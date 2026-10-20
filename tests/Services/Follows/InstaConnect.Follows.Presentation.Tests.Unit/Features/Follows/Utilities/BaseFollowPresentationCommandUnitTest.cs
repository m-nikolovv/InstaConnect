using InstaConnect.Follows.Presentation.Features.Common.Extensions;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Unit.Features.Follows.Utilities;

public abstract class BaseFollowPresentationCommandUnitTest : BaseFollowTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseFollowPresentationCommandUnitTest()
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(FollowsPresentationReference.Assembly);
	}
}
