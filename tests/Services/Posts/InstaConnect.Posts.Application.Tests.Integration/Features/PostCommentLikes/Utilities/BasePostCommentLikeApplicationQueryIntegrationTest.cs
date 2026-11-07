namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeApplicationQueryIntegrationTest : BasePostCommentLikeWebQueryTest
{
	protected IApplicationSender Sender { get; }

	protected BasePostCommentLikeApplicationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}
}
