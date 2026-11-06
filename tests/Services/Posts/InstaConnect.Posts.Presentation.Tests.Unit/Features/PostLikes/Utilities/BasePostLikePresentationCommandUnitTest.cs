using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationCommandUnitTest : BasePostsCommandTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BasePostLikePresentationCommandUnitTest()
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(PostsPresentationReference.Assembly);
	}
}
