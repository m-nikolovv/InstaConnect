namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Repositories;

public class DeleteChatCommandRepositoryIntegrationTests : BaseChatInfrastructureCommandIntegrationTest
{
	public DeleteChatCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Chat, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessages, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteChat_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Chat, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(ChatId, CancellationToken);

		// Assert
		chat.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChat_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChat = ChatBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChat, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(ChatId, CancellationToken);

		// Assert
		chat.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChat_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChat = ChatBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChat, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(ChatId, CancellationToken);

		// Assert
		chat.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChat_WhenInvertedCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChat = InvertedChatBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChat, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(ChatId, CancellationToken);

		// Assert
		chat.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChat_WhenInvertedCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChat = InvertedChatBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChat, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(ChatId, CancellationToken);

		// Assert
		chat.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteChatChatMessages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Chat, CancellationToken);
		var chatChatMessages = await ServiceScope.GetByIdRangeAsync(ChatChatMessageIds, CancellationToken);

		// Assert
		chatChatMessages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatChatMessages_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChat = ChatBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChat, CancellationToken);
		var chatChatMessages = await ServiceScope.GetByIdRangeAsync(ChatChatMessageIds, CancellationToken);

		// Assert
		chatChatMessages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatChatMessages_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChat = ChatBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChat, CancellationToken);
		var chatChatMessages = await ServiceScope.GetByIdRangeAsync(ChatChatMessageIds, CancellationToken);

		// Assert
		chatChatMessages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatChatMessages_WhenInvertedCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChat = InvertedChatBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChat, CancellationToken);
		var chatChatMessages = await ServiceScope.GetByIdRangeAsync(ChatChatMessageIds, CancellationToken);

		// Assert
		chatChatMessages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatChatMessages_WhenInvertedCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChat = InvertedChatBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChat, CancellationToken);
		var chatChatMessages = await ServiceScope.GetByIdRangeAsync(ChatChatMessageIds, CancellationToken);

		// Assert
		chatChatMessages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteChatChatMessagesChatMessageImages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Chat, CancellationToken);
		var chatChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(ChatChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		chatChatMessagesChatMessageImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatChatMessagesChatMessageImages_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChat = ChatBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChat, CancellationToken);
		var chatChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(ChatChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		chatChatMessagesChatMessageImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatChatMessagesChatMessageImages_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChat = ChatBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChat, CancellationToken);
		var chatChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(ChatChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		chatChatMessagesChatMessageImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatChatMessagesChatMessageImages_WhenInvertedCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChat = InvertedChatBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChat, CancellationToken);
		var chatChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(ChatChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		chatChatMessagesChatMessageImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatChatMessagesChatMessageImages_WhenInvertedCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedChat = InvertedChatBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedChat, CancellationToken);
		var chatChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(ChatChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		chatChatMessagesChatMessageImages.ShouldBeEmpty();
	}

}
