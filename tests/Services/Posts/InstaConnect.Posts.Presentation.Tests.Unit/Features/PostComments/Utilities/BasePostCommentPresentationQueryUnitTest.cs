using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostComments.Utilities;

public abstract class BasePostCommentPresentationQueryUnitTest : BasePostsQueryTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BasePostCommentPresentationQueryUnitTest()
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(PostsPresentationReference.Assembly);
	}
}
