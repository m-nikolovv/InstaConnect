namespace InstaConnect.Chats.Application.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatApplicationQueryIntegrationTest : BaseChatWebTest
{
	protected IApplicationSender Sender { get; }

	protected BaseChatApplicationQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ParticipantOnes, CancellationToken);
		await ServiceScope.AddRangeAsync(ParticipantTwos, CancellationToken);
		await OnInitializeAsync();
	}
}
