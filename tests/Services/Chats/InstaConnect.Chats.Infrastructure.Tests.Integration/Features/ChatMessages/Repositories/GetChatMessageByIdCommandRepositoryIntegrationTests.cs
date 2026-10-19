using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Id;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Repositories;

public class GetChatMessageByIdCommandRepositoryIntegrationTests : BaseChatMessageInfrastructureCommandIntegrationTest
{
	private readonly ChatMessageInclude _include;

	public GetChatMessageByIdCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_include = MessageIncludeBuilderFactory.Create().WithSender().WithChat().WithChatMessageImages().Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(ChatMessage, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ChatMessage, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(ChatMessageId, _include, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(ChatMessageId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageId, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = ChatMessageIdBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = ChatMessageIdBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, ChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = ChatMessageIdBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, ChatMessage);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenInvertedCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(InvertedChatMessageId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(InvertedChatMessageId, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenInvertedCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedId = InvertedChatMessageIdBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(invertedId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedId, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenInvertedCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedId = InvertedChatMessageIdBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(invertedId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedId, ChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenInvertedCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedId = InvertedChatMessageIdBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(invertedId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedId, ChatMessage);
	}
}
