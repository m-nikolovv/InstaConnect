namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public abstract class BaseChatWebTest : BaseChatTest, IClassFixture<ChatsWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseChatWebTest(ChatsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
