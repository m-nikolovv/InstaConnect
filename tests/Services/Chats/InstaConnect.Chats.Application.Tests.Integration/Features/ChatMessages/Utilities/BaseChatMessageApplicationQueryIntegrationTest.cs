namespace InstaConnect.Chats.Application.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageApplicationQueryIntegrationTest : BaseChatMessageWebTest
{
	protected IApplicationSender Sender { get; }

	protected BaseChatMessageApplicationQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ParticipantOnes, CancellationToken);
		await ServiceScope.AddRangeAsync(ParticipantTwos, CancellationToken);
		await ServiceScope.AddRangeAsync(Chats, CancellationToken);
		await OnInitializeAsync();
	}
}
