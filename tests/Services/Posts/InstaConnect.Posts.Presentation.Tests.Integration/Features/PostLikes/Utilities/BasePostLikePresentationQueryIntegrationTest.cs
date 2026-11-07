using InstaConnect.Posts.Presentation.Features.PostLikes.Controllers.v1;

namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationQueryIntegrationTest : BasePostLikeWebQueryTest
{
	protected PostLikeController Controller { get; }

	protected UserPostLikeController UserController { get; }

	protected BasePostLikePresentationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetPostLikeController();
		UserController = ServiceScope.GetUserPostLikeController();
	}
}
