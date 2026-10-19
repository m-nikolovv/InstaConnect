using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Repositories;

public class GetChatByIdCommandRepositoryIntegrationTests : BaseChatInfrastructureCommandIntegrationTest
{
	private readonly ChatInclude _include;

	public GetChatByIdCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_include = IncludeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Chat, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(ChatId, _include, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(ChatId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatId, Chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = ChatIdBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, Chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = ChatIdBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, Chat);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenInvertedCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(InvertedChatId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(InvertedChatId, Chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenInvertedCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedId = InvertedChatIdBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(invertedId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedId, Chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenInvertedCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedId = InvertedChatIdBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(invertedId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedId, Chat);
	}
}
