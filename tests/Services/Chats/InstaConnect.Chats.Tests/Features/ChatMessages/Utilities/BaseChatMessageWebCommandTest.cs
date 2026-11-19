namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageWebCommandTest : BaseChatMessageWebTest
{
	protected BaseChatMessageWebCommandTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(ParticipantOne, CurrentUserId, CancellationToken);
		await ServiceScope.AddAsync(ParticipantTwo, CurrentUserId, CancellationToken);
		await ServiceScope.AddAsync(Chat, CurrentUserId, CancellationToken);
		await OnInitializeAsync();
	}
}
