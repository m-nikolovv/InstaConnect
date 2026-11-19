namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

public abstract class BaseChatMessageImageWebCommandTest : BaseChatMessageImageWebTest
{
	protected BaseChatMessageImageWebCommandTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(ParticipantOne, CurrentUserId, CancellationToken);
		await ServiceScope.AddAsync(ParticipantTwo, CurrentUserId, CancellationToken);
		await ServiceScope.AddAsync(Chat, CurrentUserId, CancellationToken);
		await ServiceScope.AddAsync(ChatMessage, CurrentUserId, CancellationToken);
		await OnInitializeAsync();
	}
}
