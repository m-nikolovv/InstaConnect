using InstaConnect.Posts.Presentation.Features.PostComments.Controllers.v1;

namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentPresentationQueryIntegrationTest : BasePostCommentWebQueryTest
{
	protected PostCommentController Controller { get; }

	protected UserPostCommentController UserController { get; }

	protected BasePostCommentPresentationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetPostCommentController();
		UserController = ServiceScope.GetUserPostCommentController();
	}
}
