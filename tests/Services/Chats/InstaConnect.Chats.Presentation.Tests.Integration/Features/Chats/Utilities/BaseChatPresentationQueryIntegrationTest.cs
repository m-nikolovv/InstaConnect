using InstaConnect.Chats.Presentation.Features.Chats.Controllers.v1;

namespace InstaConnect.Chats.Presentation.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatPresentationQueryIntegrationTest : BaseChatWebTest
{
	protected ChatController Controller { get; }

	protected BaseChatPresentationQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetChatController();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ParticipantOnes, CancellationToken);
		await ServiceScope.AddRangeAsync(ParticipantTwos, CancellationToken);
		await OnInitializeAsync();
	}
}
