using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Id;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Repositories;

public class DeleteChatMessageCommandRepositoryIntegrationTests : BaseChatMessageInfrastructureCommandIntegrationTest
{
	public DeleteChatMessageCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(ChatMessage, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteChatMessage_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(ChatMessage, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatMessage_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChatMessage = ChatMessageBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChatMessage, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatMessage_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChatMessage = ChatMessageBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChatMessage, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatMessage_WhenCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChatMessage = ChatMessageBuilder.WithMessageId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChatMessage, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteChatMessageChatMessageImages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(ChatMessage, CancellationToken);
		var chatMessageChatMessageImages = await ServiceScope.GetByIdRangeAsync(ChatMessageChatMessageImageIds, CancellationToken);

		// Assert
		chatMessageChatMessageImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatMessageChatMessageImages_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChatMessage = ChatMessageBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChatMessage, CancellationToken);
		var chatMessageChatMessageImages = await ServiceScope.GetByIdRangeAsync(ChatMessageChatMessageImageIds, CancellationToken);

		// Assert
		chatMessageChatMessageImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatMessageChatMessageImages_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChatMessage = ChatMessageBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChatMessage, CancellationToken);
		var chatMessageChatMessageImages = await ServiceScope.GetByIdRangeAsync(ChatMessageChatMessageImageIds, CancellationToken);

		// Assert
		chatMessageChatMessageImages.ShouldBeEmpty();
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatMessageChatMessageImages_WhenCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChatMessage = ChatMessageBuilder.WithMessageId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChatMessage, CancellationToken);
		var chatMessageChatMessageImages = await ServiceScope.GetByIdRangeAsync(ChatMessageChatMessageImageIds, CancellationToken);

		// Assert
		chatMessageChatMessageImages.ShouldBeEmpty();
	}
}
