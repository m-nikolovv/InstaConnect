using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Utilities;

public abstract class BasePostApplicationQueryUnitTest : BasePostsQueryTest
{
	protected IApplicationMapper Mapper { get; }

	protected IPostQueryService Service { get; }

	protected BasePostApplicationQueryUnitTest()
	{
		Mapper = MockFactory.CreateMapper(PostsApplicationReference.Assembly);
		Service = PostApplicationMockFactory.CreateQueryService();
	}
}
