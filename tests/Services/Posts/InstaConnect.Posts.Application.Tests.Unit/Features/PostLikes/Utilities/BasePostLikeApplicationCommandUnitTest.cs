using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikeApplicationCommandUnitTest : BasePostLikeTest
{
	protected IApplicationMapper Mapper { get; }

	protected IPostLikeCommandService LikeService { get; }

	protected BasePostLikeApplicationCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(PostsApplicationReference.Assembly);
		LikeService = PostLikeApplicationMockFactory.CreateCommandService();
	}
}
