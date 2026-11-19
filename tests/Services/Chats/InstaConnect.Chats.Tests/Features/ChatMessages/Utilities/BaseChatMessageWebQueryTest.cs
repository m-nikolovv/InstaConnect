using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageWebQueryTest : BaseChatMessageWebTest
{
	protected BaseChatMessageWebQueryTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ParticipantOnes, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(ParticipantTwos, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(Chats, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessages, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
		await OnInitializeAsync();
	}
}
