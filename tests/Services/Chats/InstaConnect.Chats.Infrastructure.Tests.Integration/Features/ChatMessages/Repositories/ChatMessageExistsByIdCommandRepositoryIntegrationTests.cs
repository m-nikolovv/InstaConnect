using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Id;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Repositories;

public class ChatMessageExistsByIdCommandRepositoryIntegrationTests : BaseChatMessageInfrastructureCommandIntegrationTest
{
	public ChatMessageExistsByIdCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(ChatMessage, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ChatMessage, CancellationToken);

		// Act
		var response = await Repository.ExistsByIdAsync(ChatMessageId, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageId, chatMessage);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.ExistsByIdAsync(ChatMessageId, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageId, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = ChatMessageIdBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = ChatMessageIdBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, chatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = ChatMessageIdBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, chatMessage);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenInvertedCommandIsValid()
	{
		// Act
		var response = await Repository.ExistsByIdAsync(InvertedChatMessageId, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(InvertedChatMessageId, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenInvertedCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedId = InvertedChatMessageIdBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(invertedId, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedId, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenInvertedCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedId = InvertedChatMessageIdBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(invertedId, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedId, chatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenInvertedCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedId = InvertedChatMessageIdBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(invertedId, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedId, chatMessage);
	}
}
