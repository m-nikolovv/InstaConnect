using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserInfrastructureQueryIntegrationTest : BaseUserWebQueryTest
{
	protected IUserCacheHandler CacheHandler { get; }

	protected IUserQueryRepository Repository { get; }

	protected BaseUserInfrastructureQueryIntegrationTest(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		CacheHandler = ServiceScope.GetUserCacheHandler();
		Repository = ServiceScope.GetUserQueryRepository();
	}
}
