using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostComments.Utilities;

public abstract class BasePostCommentPresentationQueryFunctionalTest : BasePostsWebQueryTest
{
	protected IPostCommentApiClient CommentApiClient { get; }

	protected BasePostCommentPresentationQueryFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		CommentApiClient = webApplicationFactory.CreateCommentApiClient();
	}
}
