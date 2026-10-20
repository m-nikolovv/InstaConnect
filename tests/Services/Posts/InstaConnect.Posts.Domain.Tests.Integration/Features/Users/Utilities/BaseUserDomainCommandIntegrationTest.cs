using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserDomainCommandIntegrationTest : BaseUserWebTest
{
	protected IUserCommandService UserService { get; }

	protected BaseUserDomainCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		UserService = ServiceScope.GetUserCommandService();
	}
}
