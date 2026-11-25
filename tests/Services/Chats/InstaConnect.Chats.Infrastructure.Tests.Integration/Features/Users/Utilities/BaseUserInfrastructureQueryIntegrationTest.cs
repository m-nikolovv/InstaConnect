using InstaConnect.Chats.Domain.Features.Users.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserInfrastructureQueryIntegrationTest : BaseUserWebQueryTest
{
	protected IUserCacheHandler CacheHandler { get; }

	protected IUserQueryRepository Repository { get; }

	protected BaseUserInfrastructureQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		CacheHandler = ServiceScope.GetUserCacheHandler();
		Repository = ServiceScope.GetUserQueryRepository();
	}
}
