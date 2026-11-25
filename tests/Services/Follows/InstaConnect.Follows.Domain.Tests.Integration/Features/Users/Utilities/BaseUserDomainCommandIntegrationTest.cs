using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Follows.Domain.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserDomainCommandIntegrationTest : BaseUserWebCommandTest
{
	protected IUserCacheHandler CacheHandler { get; }

	protected IUserCommandService UserService { get; }

	protected BaseUserDomainCommandIntegrationTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		CacheHandler = ServiceScope.GetUserCacheHandler();
		UserService = ServiceScope.GetUserCommandService();
	}
}
