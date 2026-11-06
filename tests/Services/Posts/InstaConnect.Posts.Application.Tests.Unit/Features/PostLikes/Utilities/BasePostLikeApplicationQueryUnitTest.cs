using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikeApplicationQueryUnitTest : BasePostsQueryTest
{
	protected IApplicationMapper Mapper { get; }

	protected IPostLikeQueryService LikeService { get; }

	protected BasePostLikeApplicationQueryUnitTest()
	{
		Mapper = MockFactory.CreateMapper(PostsApplicationReference.Assembly);
		LikeService = PostLikeApplicationMockFactory.CreateQueryService();
	}
}
