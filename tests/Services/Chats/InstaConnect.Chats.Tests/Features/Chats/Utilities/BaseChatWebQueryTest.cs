namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public abstract class BaseChatWebQueryTest : BaseChatWebTest
{
	protected BaseChatWebQueryTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ParticipantOnes, CancellationToken);
		await ServiceScope.AddRangeAsync(ParticipantTwos, CancellationToken);
		await ServiceScope.AddRangeAsync(Chats, CancellationToken);
		await ServiceScope.AddRangeAsync(InvertedChats, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessages, CancellationToken);
		await OnInitializeAsync();
	}
}
