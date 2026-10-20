using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageInfrastructureQueryIntegrationTest : BaseChatMessageWebTest
{
	protected IChatMessageQueryRepository Repository { get; }

	protected BaseChatMessageInfrastructureQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetMessageQueryRepository();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ParticipantOnes, CancellationToken);
		await ServiceScope.AddRangeAsync(ParticipantTwos, CancellationToken);
		await ServiceScope.AddRangeAsync(Chats, CancellationToken);
		await OnInitializeAsync();
	}
}
