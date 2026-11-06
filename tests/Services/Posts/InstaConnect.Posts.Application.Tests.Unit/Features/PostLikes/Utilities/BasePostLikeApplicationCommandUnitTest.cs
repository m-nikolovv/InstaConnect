using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikeApplicationCommandUnitTest : BasePostsCommandTest
{
	protected IApplicationMapper Mapper { get; }

	protected IPostLikeCommandService LikeService { get; }

	protected BasePostLikeApplicationCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(PostsApplicationReference.Assembly);
		LikeService = PostLikeApplicationMockFactory.CreateCommandService();
	}
}
