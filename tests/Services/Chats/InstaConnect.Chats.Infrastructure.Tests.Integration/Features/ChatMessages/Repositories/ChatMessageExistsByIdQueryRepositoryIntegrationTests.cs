using InstaConnect.Chats.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Id;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Repositories;

public class ChatMessageExistsByIdQueryRepositoryIntegrationTests : BaseChatMessageInfrastructureQueryIntegrationTest
{
	public ChatMessageExistsByIdQueryRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
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
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.ExistsByIdAsync(ChatMessageId, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageId, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryAndParticipantOneIdAreValid(
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
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryAndParticipantTwoIdAreValid(
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
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryAndMessageIdAreValid(
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
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenInvertedQueryIsValid()
	{
		// Act
		var response = await Repository.ExistsByIdAsync(InvertedChatMessageId, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(InvertedChatMessageId, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenInvertedQueryAndParticipantOneIdAreValid(
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
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenInvertedQueryAndParticipantTwoIdAreValid(
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
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenInvertedQueryAndMessageIdAreValid(
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
