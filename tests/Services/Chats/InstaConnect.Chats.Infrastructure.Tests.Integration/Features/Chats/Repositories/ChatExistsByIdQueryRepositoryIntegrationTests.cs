using InstaConnect.Chats.Tests.Features.Chats.Builders;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Repositories;

public class ChatExistsByIdQueryRepositoryIntegrationTests : BaseChatInfrastructureQueryIntegrationTest
{
	public ChatExistsByIdQueryRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
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
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.ExistsByIdAsync(ChatId, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(ChatId, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatId, chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryAndParticipantOneIdAreValid(
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
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryAndParticipantTwoIdAreValid(
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
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenInvertedQueryIsValid()
	{
		// Act
		var response = await Repository.ExistsByIdAsync(InvertedChatId, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(ChatId, CancellationToken);

		// Assert
		response.ShouldSatisfy(InvertedChatId, chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenInvertedQueryAndParticipantOneIdAreValid(
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
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenInvertedQueryAndParticipantTwoIdAreValid(
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
