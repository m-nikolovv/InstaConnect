using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageInfrastructureCommandIntegrationTest : BaseChatMessageWebTest
{
	protected IChatMessageCommandRepository Repository { get; }

	protected IChatMessageIncludeBuilderFactory MessageIncludeBuilderFactory { get; }

	protected BaseChatMessageInfrastructureCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetMessageCommandRepository();
		MessageIncludeBuilderFactory = ServiceScope.GetMessageIncludeBuilderFactory();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(ParticipantOne, CancellationToken);
		await ServiceScope.AddAsync(ParticipantTwo, CancellationToken);
		await ServiceScope.AddAsync(Chat, CancellationToken);
		await OnInitializeAsync();
	}
}
