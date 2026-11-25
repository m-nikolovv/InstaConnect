using InstaConnect.Chats.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserApplicationCommandIntegrationTest : BaseUserWebCommandTest
{
	protected IApplicationSender Sender { get; }

	protected IUserCacheHandler CacheHandler { get; }

	protected BaseUserApplicationCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		CacheHandler = ServiceScope.GetUserCacheHandler();
	}
}
