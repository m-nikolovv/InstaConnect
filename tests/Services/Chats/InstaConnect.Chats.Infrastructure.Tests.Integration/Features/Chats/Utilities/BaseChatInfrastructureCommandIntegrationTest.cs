using InstaConnect.Chats.Domain.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatInfrastructureCommandIntegrationTest : BaseChatWebCommandTest
{
	protected IChatCommandRepository Repository { get; }

	protected IChatIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseChatInfrastructureCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetIncludeBuilderFactory();
	}
}
