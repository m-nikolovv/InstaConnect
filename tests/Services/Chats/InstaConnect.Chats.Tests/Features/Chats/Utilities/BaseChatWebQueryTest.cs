namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public abstract class BaseChatWebQueryTest : BaseChatWebTest
{
	protected BaseChatWebQueryTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ParticipantOnes, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(ParticipantTwos, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(Chats, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessages, CurrentUserId, CancellationToken);
		await OnInitializeAsync();
	}
}
