using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessages.Repositories;

public class GetChatMessageByIdQueryRepositoryUnitTests : BaseChatMessageInfrastructureQueryUnitTest
{
	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly ChatInclude _include;
	private readonly ChatMessageInclude _messageInclude;

	private readonly ChatMessageQueryRepository _repository;

	public GetChatMessageByIdQueryRepositoryUnitTests()
	{
		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(ParticipantOne);
		_currentUserQuery = _currentUserQueryBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().WithChatMessages().Build();
		_messageInclude = MessageIncludeBuilderFactory.Create().WithSender().WithChat(_include).WithChatMessageImages().Build();

		_repository = new(Collection, MessageCacheHandler, IncludeBuilderFactory, MessageIncludeBuilderFactory);

		Collection.SetupAggregateFluent(ChatMessageId, _currentUserQuery, Fluent);
		Fluent.SetupInclude(ChatMessageId, _currentUserQuery, _messageInclude);
		Fluent.SetupMatch(ChatMessageId, _currentUserQuery);
		Fluent.SetupProjectToFullResponse(ChatMessageId, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupFirstOrDefaultAsync(ChatMessageId, _currentUserQuery, ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenResponseIsNotCached()
	{
		// Act
		var response = await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageId, _currentUserQuery, ChatMessage);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheMessageCacheHandlerGetByIdAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		await MessageCacheHandler.ShouldHaveReceivedOneGetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ChatMessageId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentInclude_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(ChatMessageId, _currentUserQuery, _messageInclude);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ChatMessageId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(ChatMessageId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(ChatMessageId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheMessageCacheHandlerAddAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		await MessageCacheHandler.ShouldHaveReceivedOneAddAsync(ChatMessage, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenResponseIsCached()
	{
		// Arrange
		MessageCacheHandler.SetupGetByIdAsync(ChatMessageId, _currentUserQuery, ChatMessage, CancellationToken);

		// Act
		var response = await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageId, _currentUserQuery, ChatMessage);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheMessageCacheHandlerGetByIdAsync_WhenResponseIsCached()
	{
		// Arrange
		MessageCacheHandler.SetupGetByIdAsync(ChatMessageId, _currentUserQuery, ChatMessage, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		await MessageCacheHandler.ShouldHaveReceivedOneGetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCollectionAggregateFluent_WhenResponseIsCached()
	{
		// Arrange
		MessageCacheHandler.SetupGetByIdAsync(ChatMessageId, _currentUserQuery, ChatMessage, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedZeroAggregateFluent(ChatMessageId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentInclude_WhenResponseIsCached()
	{
		// Arrange
		MessageCacheHandler.SetupGetByIdAsync(ChatMessageId, _currentUserQuery, ChatMessage, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroInclude(ChatMessageId, _currentUserQuery, _messageInclude);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentMatch_WhenResponseIsCached()
	{
		// Arrange
		MessageCacheHandler.SetupGetByIdAsync(ChatMessageId, _currentUserQuery, ChatMessage, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroMatch(ChatMessageId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentProjectToFullResponse_WhenResponseIsCached()
	{
		// Arrange
		MessageCacheHandler.SetupGetByIdAsync(ChatMessageId, _currentUserQuery, ChatMessage, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroProjectToFullResponse(ChatMessageId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheResponseFluentFirstOrDefaultAsync_WhenResponseIsCached()
	{
		// Arrange
		MessageCacheHandler.SetupGetByIdAsync(ChatMessageId, _currentUserQuery, ChatMessage, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedZeroFirstOrDefaultAsync(ChatMessageId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheMessageCacheHandlerAddAsync_WhenResponseIsCached()
	{
		// Arrange
		MessageCacheHandler.SetupGetByIdAsync(ChatMessageId, _currentUserQuery, ChatMessage, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		await MessageCacheHandler.ShouldHaveReceivedZeroAddAsync(ChatMessage, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenChatMessageIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Act
		var response = await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheMessageCacheHandlerGetByIdAsync_WhenChatMessageIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		await MessageCacheHandler.ShouldHaveReceivedOneGetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenChatMessageIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ChatMessageId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentInclude_WhenChatMessageIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(ChatMessageId, _currentUserQuery, _messageInclude);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenChatMessageIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ChatMessageId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenChatMessageIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(ChatMessageId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenChatMessageIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(ChatMessageId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheMessageCacheHandlerAddAsync_WhenChatMessageIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		await MessageCacheHandler.ShouldHaveReceivedZeroAddAsync(ChatMessage, _currentUserQuery, CancellationToken);
	}
}
