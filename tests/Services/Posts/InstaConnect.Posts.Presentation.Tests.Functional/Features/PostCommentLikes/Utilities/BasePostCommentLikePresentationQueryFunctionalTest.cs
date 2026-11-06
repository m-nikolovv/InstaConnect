using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationQueryFunctionalTest : BasePostsWebQueryTest
{
	protected IPostCommentLikeApiClient CommentLikeApiClient { get; }

	protected BasePostCommentLikePresentationQueryFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		CommentLikeApiClient = webApplicationFactory.CreateCommentLikeApiClient();
	}
}
