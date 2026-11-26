using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Id;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.ChatMessages.Services;

public class GetChatMessageByIdQueryServiceIntegrationTests : BaseChatMessageDomainQueryIntegrationTest
{
	private readonly GetChatMessageByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly GetChatMessageByIdQueryBuilder _queryBuilder;
	private readonly GetChatMessageByIdQuery _query;

	private readonly GetChatMessageByIdQueryBuilder _invertedQueryBuilder;
	private readonly GetChatMessageByIdQuery _invertedQuery;

	public GetChatMessageByIdQueryServiceIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(ChatMessage, CurrentUserId);
		_query = _queryBuilder.Build();

		_invertedQueryBuilder = _queryBuilderFactory.Create(ChatMessage, CurrentUserId).WithCurrentUserId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		_invertedQuery = _invertedQueryBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeGetByIdAsync(_query, ChatMessage, CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeGetByIdAsync(_query, ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowChatNotFoundException_WhenChatNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Assert
		await Service.ShouldThrowChatNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowChatMessageNotFoundException_WhenChatMessageNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ChatMessage, CancellationToken);

		// Assert
		await Service.ShouldThrowChatMessageNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, ChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, ChatMessage);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCacheChatMessage_WhenQueryIsValid()
	{
		// Act
		await Service.GetByIdAsync(_query, CancellationToken);
		var cachedChatMessage = await ServiceScope.GetChatMessageCacheByIdAsync(_query, CancellationToken);

		// Assert
		cachedChatMessage.ShouldSatisfy(_query, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCacheChatMessage_WhenQueryAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Service.GetByIdAsync(query, CancellationToken);
		var cachedChatMessage = await ServiceScope.GetChatMessageCacheByIdAsync(query, CancellationToken);

		// Assert
		cachedChatMessage.ShouldSatisfy(query, ChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCacheChatMessage_WhenQueryAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithMessageId(transformer).Build();

		// Act
		await Service.GetByIdAsync(query, CancellationToken);
		var cachedChatMessage = await ServiceScope.GetChatMessageCacheByIdAsync(query, CancellationToken);

		// Assert
		cachedChatMessage.ShouldSatisfy(query, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCacheChatMessage_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		await Service.GetByIdAsync(query, CancellationToken);
		var cachedChatMessage = await ServiceScope.GetChatMessageCacheByIdAsync(query, CancellationToken);

		// Assert
		cachedChatMessage.ShouldSatisfy(query, ChatMessage);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnInvertedResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetByIdAsync(_invertedQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(_invertedQuery, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnInvertedResponse_WhenQueryAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedQuery = _invertedQueryBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(invertedQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedQuery, ChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnInvertedResponse_WhenQueryAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedQuery = _invertedQueryBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(invertedQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedQuery, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnInvertedResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedQuery = _invertedQueryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(invertedQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedQuery, ChatMessage);
	}
}
