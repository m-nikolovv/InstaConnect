using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationCommandFunctionalTest : BasePostsWebCommandTest
{
	protected IPostCommentLikeApiClient CommentLikeApiClient { get; }

	protected IPostCommentLikeEventClient CommentLikeEventClient { get; }

	protected BasePostCommentLikePresentationCommandFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		CommentLikeApiClient = webApplicationFactory.CreateCommentLikeApiClient();
		CommentLikeEventClient = webApplicationFactory.CreateCommentLikeEventClient();
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await CommentLikeEventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await CommentLikeEventClient.StopAsync(CancellationToken);
	}
}
