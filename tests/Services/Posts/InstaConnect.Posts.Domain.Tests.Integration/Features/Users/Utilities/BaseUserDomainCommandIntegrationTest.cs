using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserDomainCommandIntegrationTest : BaseUserWebCommandTest
{
	protected IUserCacheHandler CacheHandler { get; }

	protected IUserCommandService UserService { get; }

	protected BaseUserDomainCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		CacheHandler = ServiceScope.GetUserCacheHandler();
		UserService = ServiceScope.GetUserCommandService();
	}
}
