using InstaConnect.Chats.Domain.Features.Users.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserInfrastructureQueryIntegrationTest : BaseUserWebQueryTest
{
	protected IUserQueryRepository Repository { get; }

	protected BaseUserInfrastructureQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetUserQueryRepository();
	}
}
