namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

public abstract class BaseChatMessageImageWebCommandTest : BaseChatMessageImageWebTest
{
	protected BaseChatMessageImageWebCommandTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(ParticipantOne, CancellationToken);
		await ServiceScope.AddAsync(ParticipantTwo, CancellationToken);
		await ServiceScope.AddAsync(Chat, CancellationToken);
		await ServiceScope.AddAsync(ChatMessage, CancellationToken);
		await OnInitializeAsync();
	}
}
