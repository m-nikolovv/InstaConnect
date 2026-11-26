using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageInfrastructureCommandIntegrationTest : BaseChatMessageWebCommandTest
{
	protected IChatMessageCommandRepository Repository { get; }

	protected IChatMessageIncludeBuilderFactory MessageIncludeBuilderFactory { get; }

	protected BaseChatMessageInfrastructureCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetMessageCommandRepository();
		MessageIncludeBuilderFactory = ServiceScope.GetMessageIncludeBuilderFactory();
	}
}
