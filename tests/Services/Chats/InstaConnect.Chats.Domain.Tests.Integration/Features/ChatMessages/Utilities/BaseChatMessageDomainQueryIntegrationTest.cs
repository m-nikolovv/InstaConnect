using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageDomainQueryIntegrationTest : BaseChatMessageWebTest
{
	protected IChatMessageQueryService Service { get; }

	protected BaseChatMessageDomainQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Service = ServiceScope.GetChatMessageQueryService();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ParticipantOnes, CancellationToken);
		await ServiceScope.AddRangeAsync(ParticipantTwos, CancellationToken);
		await ServiceScope.AddRangeAsync(Chats, CancellationToken);
		await OnInitializeAsync();
	}
}
