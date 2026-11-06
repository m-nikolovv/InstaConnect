using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Utilities;

public abstract class BasePostApplicationCommandUnitTest : BasePostsCommandTest
{
	protected IApplicationMapper Mapper { get; }

	protected IPostCommandService Service { get; }

	protected BasePostApplicationCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(PostsApplicationReference.Assembly);
		Service = PostApplicationMockFactory.CreateCommandService();
	}
}
