using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserApplicationCommandUnitTest : BasePostsCommandTest
{
	protected IApplicationMapper Mapper { get; }

	protected IUserCommandService UserService { get; }

	protected BaseUserApplicationCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(PostsApplicationReference.Assembly);
		UserService = UserApplicationMockFactory.CreateCommandService();
	}
}
