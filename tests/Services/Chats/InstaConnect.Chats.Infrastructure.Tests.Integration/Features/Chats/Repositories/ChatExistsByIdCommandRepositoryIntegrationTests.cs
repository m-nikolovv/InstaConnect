using InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Repositories;

public class ChatExistsByIdCommandRepositoryIntegrationTests : BaseChatInfrastructureCommandIntegrationTest
{
	public ChatExistsByIdCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Chat, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Act
		var response = await Repository.ExistsByIdAsync(ChatId, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(ChatId, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatId, chat);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.ExistsByIdAsync(ChatId, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(ChatId, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatId, chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = ChatIdBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(ChatId, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = ChatIdBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(ChatId, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, chat);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenInvertedCommandIsValid()
	{
		// Act
		var response = await Repository.ExistsByIdAsync(InvertedChatId, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(ChatId, CancellationToken);

		// Assert
		response.ShouldSatisfy(InvertedChatId, chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenInvertedCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedId = InvertedChatIdBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(invertedId, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(ChatId, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedId, chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenInvertedCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedId = InvertedChatIdBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(invertedId, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(ChatId, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedId, chat);
	}
}
