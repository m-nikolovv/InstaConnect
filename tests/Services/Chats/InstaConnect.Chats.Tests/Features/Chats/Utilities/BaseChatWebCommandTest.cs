namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public abstract class BaseChatWebCommandTest : BaseChatWebTest
{
	protected BaseChatWebCommandTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(ParticipantOne, CurrentUserId, CancellationToken);
		await ServiceScope.AddAsync(ParticipantTwo, CurrentUserId, CancellationToken);
		await OnInitializeAsync();
	}
}
