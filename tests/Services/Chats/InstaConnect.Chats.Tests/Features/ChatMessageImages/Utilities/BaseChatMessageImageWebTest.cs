namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

public abstract class BaseChatMessageImageWebTest : BaseChatMessageImageTest, IClassFixture<ChatsWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseChatMessageImageWebTest(ChatsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
