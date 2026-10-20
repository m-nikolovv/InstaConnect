using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessages.Repositories;

public class GetChatMessageByIdCommandRepositoryUnitTests : BaseChatMessageInfrastructureCommandUnitTest
{
	private readonly ChatMessageInclude _include;

	private readonly ChatMessageCommandRepository _repository;

	public GetChatMessageByIdCommandRepositoryUnitTests()
	{
		_include = MessageIncludeBuilderFactory.Create().WithSender().WithChat().Build();

		_repository = new(Collection, MessageIncludeBuilderFactory);

		Collection.SetupAggregateFluent(ChatMessageId, Fluent);
		Fluent.SetupApplyIncludes(ChatMessageId, _include);
		Fluent.SetupMatch(ChatMessageId);
		Fluent.SetupFirstOrDefaultAsync(ChatMessageId, ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(ChatMessageId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageId, ChatMessage);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageId, _include, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ChatMessageId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentApplyIncludes_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageId, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(ChatMessageId, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageId, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ChatMessageId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentFirstOrDefaultAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageId, _include, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(ChatMessageId, CancellationToken);
	}
}
