using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.SortOrder;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.SortTerm;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.ChatMessages.Services;

public class GetAllChatMessagesQueryServiceIntegrationTests : BaseChatMessageDomainQueryIntegrationTest
{
	private readonly GetAllChatMessagesQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllChatMessagesQueryBuilder _queryBuilder;
	private readonly GetAllChatMessagesQuery _query;

	private readonly GetAllChatMessagesQueryBuilder _invertedQueryBuilder;
	private readonly GetAllChatMessagesQuery _invertedQuery;

	public GetAllChatMessagesQueryServiceIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(ChatMessage);
		_query = _queryBuilder.Build();

		_invertedQueryBuilder = _queryBuilderFactory.Create(ChatMessage).WithCurrentUserId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		_invertedQuery = _invertedQueryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ChatMessages, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowChatNotFoundException_WhenChatNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Assert
		await Service.ShouldThrowChatNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, Chat, ChatMessages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Chat, ChatMessages);
	}

	[Theory]
	[ChatMessagesSortOrderWithAscendingTermData]
	[ChatMessagesSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Chat, ChatMessages, termTransformer);
	}

	[Theory]
	[ChatMessagesSortTermWithCreatedAtTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<ChatMessagesSortTerm> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Chat, ChatMessages, termTransformer);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Chat, ChatMessages);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetAllAsync(_invertedQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(_invertedQuery, Chat, ChatMessages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedQuery = _invertedQueryBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(invertedQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedQuery, Chat, ChatMessages);
	}

	[Theory]
	[ChatMessagesSortOrderWithAscendingTermData]
	[ChatMessagesSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
	{
		// Arrange
		var invertedQuery = _invertedQueryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(invertedQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedQuery, Chat, ChatMessages, termTransformer);
	}

	[Theory]
	[ChatMessagesSortTermWithCreatedAtTermData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<ChatMessagesSortTerm> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
	{
		// Arrange
		var invertedQuery = _invertedQueryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(invertedQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedQuery, Chat, ChatMessages, termTransformer);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedQuery = _invertedQueryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(invertedQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedQuery, Chat, ChatMessages);
	}
}
