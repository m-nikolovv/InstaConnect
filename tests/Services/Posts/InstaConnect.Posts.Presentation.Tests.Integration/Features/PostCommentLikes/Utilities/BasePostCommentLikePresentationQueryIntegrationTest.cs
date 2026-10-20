using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Controllers.v1;

namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationQueryIntegrationTest : BasePostCommentLikeWebTest
{
	protected PostCommentLikeController Controller { get; }

	protected UserPostCommentLikeController UserController { get; }

	protected BasePostCommentLikePresentationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetPostCommentLikeController();
		UserController = ServiceScope.GetUserPostCommentLikeController();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(Posts, CancellationToken);
		await ServiceScope.AddRangeAsync(PostLikes, CancellationToken);
		await ServiceScope.AddRangeAsync(PostComments, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentImages, CancellationToken);
		await OnInitializeAsync();
	}
}
