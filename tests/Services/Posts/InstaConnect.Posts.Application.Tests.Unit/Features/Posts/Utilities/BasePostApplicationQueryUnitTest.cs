using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Utilities;

public abstract class BasePostApplicationQueryUnitTest : BasePostTest
{
	protected IApplicationMapper Mapper { get; }

	protected IPostQueryService Service { get; }

	protected BasePostApplicationQueryUnitTest()
	{
		Mapper = MockFactory.CreateMapper(PostsApplicationReference.Assembly);
		Service = PostApplicationMockFactory.CreateQueryService();
	}
}
