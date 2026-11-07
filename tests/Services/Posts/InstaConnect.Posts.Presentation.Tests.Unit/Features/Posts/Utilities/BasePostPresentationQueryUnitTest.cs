using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.Posts.Utilities;

public abstract class BasePostPresentationQueryUnitTest : BasePostQueryTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BasePostPresentationQueryUnitTest()
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(PostsPresentationReference.Assembly);
	}
}
