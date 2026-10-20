using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Controllers.v1;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationCommandIntegrationTest : BasePostCommentLikeWebTest
{
	protected PostCommentLikeController Controller { get; }

	protected IPostCommentLikeEventClient CommentLikeEventClient { get; }

	protected BasePostCommentLikePresentationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetPostCommentLikeController();
		CommentLikeEventClient = webApplicationFactory.CreateCommentLikeEventClient();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(Post, CancellationToken);
		await ServiceScope.AddAsync(PostComment, CancellationToken);
		await OnInitializeAsync();
		await CommentLikeEventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await CommentLikeEventClient.StopAsync(CancellationToken);
	}
}
