namespace InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Services;

public class GetChatMessageByIdQueryServiceUnitTests : BaseChatMessageDomainQueryUnitTest
{
	private readonly GetChatMessageByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly GetChatMessageByIdQueryBuilder _queryBuilder;
	private readonly GetChatMessageByIdQuery _query;

	private readonly ChatMessageQueryService _service;

	public GetChatMessageByIdQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(ChatMessage);
		_query = _queryBuilder.Build();

		_service = new(Repository, MessageRepository, CollectionResponseFactory);

		Repository.SetupExistsByIdAsync(_query, CancellationToken);
		MessageRepository.SetupGetByIdAsync(_query, ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowChatNotFoundException_WhenChatNotFound()
	{
		// Arrange
		Repository.RemoveExistsByIdAsync(_query, CancellationToken);

		// Assert
		await _service.ShouldThrowChatNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowChatMessageNotFoundException_WhenChatMessageNotFound()
	{
		// Arrange
		MessageRepository.RemoveGetByIdAsync(_query, ChatMessage, CancellationToken);

		// Assert
		await _service.ShouldThrowChatMessageNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, ChatMessage);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheRepositoryExistsByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneExistsByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheMessageRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		await MessageRepository.ShouldHaveReceivedOneGetByIdAsync(_query, CancellationToken);
	}
}
