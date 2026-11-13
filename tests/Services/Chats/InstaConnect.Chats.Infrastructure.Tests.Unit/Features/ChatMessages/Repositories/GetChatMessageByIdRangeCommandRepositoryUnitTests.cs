using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessages.Repositories;

public class GetChatMessageByIdRangeCommandRepositoryUnitTests : BaseChatMessageInfrastructureCommandUnitTest
{
	private readonly ChatMessageInclude _include;

	private readonly ChatMessageCommandRepository _repository;

	public GetChatMessageByIdRangeCommandRepositoryUnitTests()
	{
		_include = MessageIncludeBuilderFactory.Create().WithSender().WithChat().Build();

		_repository = new(Collection, MessageIncludeBuilderFactory);

		Collection.SetupAggregateFluent(ChatMessageIds, Fluent);
		Fluent.SetupInclude(ChatMessageIds, _include);
		Fluent.SetupMatch(ChatMessageIds);
		Fluent.SetupToListAsync(ChatMessageIds, ChatMessages, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdRangeAsync(ChatMessageIds, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageIds, ChatMessages);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(ChatMessageIds, _include, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ChatMessageIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentInclude_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(ChatMessageIds, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(ChatMessageIds, _include);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(ChatMessageIds, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ChatMessageIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentToListAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(ChatMessageIds, _include, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneToListAsync(ChatMessageIds, CancellationToken);
	}
}
