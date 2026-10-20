using InstaConnect.Chats.Domain.Features.Users.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserInfrastructureCommandIntegrationTest : BaseUserWebTest
{
	protected IUserCommandRepository Repository { get; }

	protected IUserIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseUserInfrastructureCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetUserCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetUserIncludeBuilderFactory();
	}
}
