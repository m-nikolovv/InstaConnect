using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Id;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Repositories;

public class GetChatMessageByIdRangeCommandRepositoryIntegrationTests : BaseChatMessageInfrastructureCommandIntegrationTest
{
	public GetChatMessageByIdRangeCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ChatMessages, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnEmpty_WhenIdsAreInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Act
		var response = await Repository.GetByIdRangeAsync(ChatMessageIds, CancellationToken);

		// Assert
		response.ShouldBeEmpty();
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdRangeAsync(ChatMessageIds, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndParticipantOneIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = ChatMessageIdRangeBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndParticipantTwoIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = ChatMessageIdRangeBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessages);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndMessageIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = ChatMessageIdRangeBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessages);
	}
}
