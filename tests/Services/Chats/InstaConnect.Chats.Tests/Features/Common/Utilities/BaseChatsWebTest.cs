namespace InstaConnect.Chats.Tests.Features.Common.Utilities;

public abstract class BaseChatsWebTest : BaseChatsTest, IClassFixture<ChatsWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseChatsWebTest(ChatsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
