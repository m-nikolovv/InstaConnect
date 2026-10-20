using InstaConnect.Chats.Domain.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatInfrastructureQueryIntegrationTest : BaseChatWebTest
{
	protected IChatQueryRepository Repository { get; }

	protected BaseChatInfrastructureQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetQueryRepository();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ParticipantOnes, CancellationToken);
		await ServiceScope.AddRangeAsync(ParticipantTwos, CancellationToken);
		await OnInitializeAsync();
	}
}
