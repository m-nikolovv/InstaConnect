using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.SortOrder;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.SortTerm;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Repositories;

public class GetAllChatMessagesQueryRepositoryIntegrationTests : BaseChatMessageInfrastructureQueryIntegrationTest
{
	private readonly ChatMessagesFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly ChatMessagesFilterQueryBuilder _filterQueryBuilder;
	private readonly ChatMessagesFilterQuery _filterQuery;

	private readonly ChatMessagesFilterQueryBuilder _invertedFilterQueryBuilder;
	private readonly ChatMessagesFilterQuery _invertedFilterQuery;

	private readonly ChatMessagesSortingQueryBuilderFactory _sortingQueryBuilderFactory;
	private readonly ChatMessagesSortingQueryBuilder _sortingQueryBuilder;
	private readonly ChatMessagesSortingQuery _sortingQuery;

	private readonly ChatMessagesPaginationQueryBuilderFactory _paginationQueryBuilderFactory;
	private readonly ChatMessagesPaginationQueryBuilder _paginationQueryBuilder;
	private readonly ChatMessagesPaginationQuery _paginationQuery;

	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly CurrentUserQueryBuilder _invertedCurrentUserQueryBuilder;
	private readonly CurrentUserQuery _invertedCurrentUserQuery;

	public GetAllChatMessagesQueryRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(ChatMessage);
		_filterQuery = _filterQueryBuilder.Build();

		_invertedFilterQueryBuilder = _filterQueryBuilderFactory.Create(ChatMessage).WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		_invertedFilterQuery = _invertedFilterQueryBuilder.Build();

		_sortingQueryBuilderFactory = new();
		_sortingQueryBuilder = _sortingQueryBuilderFactory.Create();
		_sortingQuery = _sortingQueryBuilder.Build();

		_paginationQueryBuilderFactory = new();
		_paginationQueryBuilder = _paginationQueryBuilderFactory.Create();
		_paginationQuery = _paginationQueryBuilder.Build();

		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(ParticipantOne);
		_currentUserQuery = _currentUserQueryBuilder.Build();

		_invertedCurrentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(ParticipantTwo);
		_invertedCurrentUserQuery = _invertedCurrentUserQueryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ChatMessages, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, Chat, ChatMessages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, Chat, ChatMessages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, Chat, ChatMessages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var currentUserQuery = _currentUserQueryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, _sortingQuery, _paginationQuery, currentUserQuery, Chat, ChatMessages);
	}

	[Theory]
	[ChatMessagesSortOrderWithAscendingTermData]
	[ChatMessagesSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
	{
		// Arrange
		var sortingQuery = _sortingQueryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, Chat, ChatMessages, termTransformer);
	}

	[Theory]
	[ChatMessagesSortTermWithCreatedAtTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<ChatMessagesSortTerm> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
	{
		// Arrange
		var sortingQuery = _sortingQueryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, Chat, ChatMessages, termTransformer);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetAllAsync(_invertedFilterQuery, _sortingQuery, _paginationQuery, _invertedCurrentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(_invertedFilterQuery, _sortingQuery, _paginationQuery, _invertedCurrentUserQuery, Chat, ChatMessages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedFilterQuery = _invertedFilterQueryBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(invertedFilterQuery, _sortingQuery, _paginationQuery, _invertedCurrentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedFilterQuery, _sortingQuery, _paginationQuery, _invertedCurrentUserQuery, Chat, ChatMessages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedFilterQuery = _invertedFilterQueryBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(invertedFilterQuery, _sortingQuery, _paginationQuery, _invertedCurrentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedFilterQuery, _sortingQuery, _paginationQuery, _invertedCurrentUserQuery, Chat, ChatMessages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedCurrentUserQuery = _invertedCurrentUserQueryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(_invertedFilterQuery, _sortingQuery, _paginationQuery, invertedCurrentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(_invertedFilterQuery, _sortingQuery, _paginationQuery, invertedCurrentUserQuery, Chat, ChatMessages);
	}

	[Theory]
	[ChatMessagesSortOrderWithAscendingTermData]
	[ChatMessagesSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
	{
		// Arrange
		var sortingQuery = _sortingQueryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(_invertedFilterQuery, sortingQuery, _paginationQuery, _invertedCurrentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(_invertedFilterQuery, sortingQuery, _paginationQuery, _invertedCurrentUserQuery, Chat, ChatMessages, termTransformer);
	}

	[Theory]
	[ChatMessagesSortTermWithCreatedAtTermData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<ChatMessagesSortTerm> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
	{
		// Arrange
		var sortingQuery = _sortingQueryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(_invertedFilterQuery, sortingQuery, _paginationQuery, _invertedCurrentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(_invertedFilterQuery, sortingQuery, _paginationQuery, _invertedCurrentUserQuery, Chat, ChatMessages, termTransformer);
	}
}
