using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentApplicationQueryIntegrationTest : BasePostCommentWebQueryTest
{
	protected IApplicationSender Sender { get; }

	protected IPostCommentCacheHandler CommentCacheHandler { get; }

	protected BasePostCommentApplicationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		CommentCacheHandler = ServiceScope.GetPostCommentCacheHandler();
	}
}
