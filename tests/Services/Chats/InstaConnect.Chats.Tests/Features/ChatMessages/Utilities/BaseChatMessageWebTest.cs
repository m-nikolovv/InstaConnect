namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageWebTest : BaseChatMessageTest, IClassFixture<ChatsWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseChatMessageWebTest(ChatsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
