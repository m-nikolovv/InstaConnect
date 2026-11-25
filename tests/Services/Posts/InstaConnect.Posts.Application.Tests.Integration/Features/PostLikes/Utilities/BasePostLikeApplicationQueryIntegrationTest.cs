using InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikeApplicationQueryIntegrationTest : BasePostLikeWebQueryTest
{
	protected IApplicationSender Sender { get; }

	protected IPostLikeCacheHandler LikeCacheHandler { get; }

	protected BasePostLikeApplicationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		LikeCacheHandler = ServiceScope.GetPostLikeCacheHandler();
	}
}
