using InstaConnect.Chats.Domain.Features.ChatMessageImages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessageImages.Utilities;

public abstract class BaseChatMessageImageInfrastructureCommandIntegrationTest : BaseChatMessageImageWebCommandTest
{
	protected IChatMessageImageCommandRepository Repository { get; }

	protected BaseChatMessageImageInfrastructureCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetMessageImageCommandRepository();
	}
}
