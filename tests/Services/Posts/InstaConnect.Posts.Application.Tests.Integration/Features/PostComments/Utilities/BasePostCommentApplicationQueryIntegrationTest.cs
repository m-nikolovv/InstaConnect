namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentApplicationQueryIntegrationTest : BasePostsWebQueryTest
{
	protected IApplicationSender Sender { get; }

	protected BasePostCommentApplicationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}
}
