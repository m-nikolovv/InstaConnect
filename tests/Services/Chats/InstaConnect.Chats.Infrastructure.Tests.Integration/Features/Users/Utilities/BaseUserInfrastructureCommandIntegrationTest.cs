using InstaConnect.Chats.Domain.Features.Users.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserInfrastructureCommandIntegrationTest : BaseUserWebCommandTest
{
	protected IUserCacheHandler CacheHandler { get; }

	protected IUserCommandRepository Repository { get; }

	protected IUserIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseUserInfrastructureCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		CacheHandler = ServiceScope.GetUserCacheHandler();
		Repository = ServiceScope.GetUserCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetUserIncludeBuilderFactory();
	}
}
