namespace InstaConnect.Chats.Tests.Features.Common.Utilities;

public abstract class BaseChatsWebCommandTest : BaseChatsCommandTest, IClassFixture<ChatsWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseChatsWebCommandTest(ChatsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
