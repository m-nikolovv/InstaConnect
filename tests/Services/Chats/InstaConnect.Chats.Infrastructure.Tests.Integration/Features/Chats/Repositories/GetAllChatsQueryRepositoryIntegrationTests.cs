using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Features.Users.Models.Requests;
using InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Infrastructure.Tests.Features.Common.Builders;
using InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.DataAttributes.SortOrder;
using InstaConnect.Chats.Tests.Features.Chats.DataAttributes.SortTerm;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Repositories;

public class GetAllChatsQueryRepositoryIntegrationTests : BaseChatInfrastructureQueryIntegrationTest
{
	private readonly ChatsFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly ChatsFilterQueryBuilder _filterQueryBuilder;
	private readonly ChatsFilterQuery _filterQuery;

	private readonly ChatsFilterQueryBuilder _invertedFilterQueryBuilder;
	private readonly ChatsFilterQuery _invertedFilterQuery;

	private readonly ChatsSortingQueryBuilderFactory _sortingQueryBuilderFactory;
	private readonly ChatsSortingQueryBuilder _sortingQueryBuilder;
	private readonly ChatsSortingQuery _sortingQuery;

	private readonly ChatsPaginationQueryBuilderFactory _paginationQueryBuilderFactory;
	private readonly ChatsPaginationQueryBuilder _paginationQueryBuilder;
	private readonly ChatsPaginationQuery _paginationQuery;

	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly CurrentUserQueryBuilder _invertedCurrentUserQueryBuilder;
	private readonly CurrentUserQuery _invertedCurrentUserQuery;

	public GetAllChatsQueryRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(Chat);
		_filterQuery = _filterQueryBuilder.Build();

		_invertedFilterQueryBuilder = _filterQueryBuilderFactory.Create(Chat).WithParticipantOneId(ParticipantTwoId).WithParticipantTwoName(ParticipantOne.Name);
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
		await ServiceScope.AddRangeAsync(Chats, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, ParticipantOne, Chats);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndParticipantTwoNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithParticipantTwoName(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, ParticipantOne, Chats);
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
		response.ShouldSatisfy(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, ParticipantOne, Chats);
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
		response.ShouldSatisfy(_filterQuery, _sortingQuery, _paginationQuery, currentUserQuery, ParticipantOne, Chats);
	}

	[Theory]
	[ChatsSortOrderWithAscendingTermData]
	[ChatsSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Chat> termTransformer)
	{
		// Arrange
		var sortingQuery = _sortingQueryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, ParticipantOne, Chats, termTransformer);
	}

	[Theory]
	[ChatsSortTermWithCreatedAtTermData]
	[ChatsSortTermWithParticipantTwoNameTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<ChatsSortTerm> transformer, ISortEnumTermTransformer<Chat> termTransformer)
	{
		// Arrange
		var sortingQuery = _sortingQueryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, ParticipantOne, Chats, termTransformer);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetAllAsync(_invertedFilterQuery, _sortingQuery, _paginationQuery, _invertedCurrentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(_invertedFilterQuery, _sortingQuery, _paginationQuery, _invertedCurrentUserQuery, ParticipantTwo, Chats);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndParticipantTwoNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedFilterQuery = _invertedFilterQueryBuilder.WithParticipantTwoName(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(invertedFilterQuery, _sortingQuery, _paginationQuery, _invertedCurrentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedFilterQuery, _sortingQuery, _paginationQuery, _invertedCurrentUserQuery, ParticipantTwo, Chats);
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
		response.ShouldSatisfyInverted(invertedFilterQuery, _sortingQuery, _paginationQuery, _invertedCurrentUserQuery, ParticipantTwo, Chats);
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
		response.ShouldSatisfyInverted(_invertedFilterQuery, _sortingQuery, _paginationQuery, invertedCurrentUserQuery, ParticipantTwo, Chats);
	}

	[Theory]
	[ChatsSortOrderWithAscendingTermData]
	[ChatsSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Chat> termTransformer)
	{
		// Arrange
		var sortingQuery = _sortingQueryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(_invertedFilterQuery, sortingQuery, _paginationQuery, _invertedCurrentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(_invertedFilterQuery, sortingQuery, _paginationQuery, _invertedCurrentUserQuery, ParticipantTwo, Chats, termTransformer);
	}

	[Theory]
	[ChatsSortTermWithCreatedAtTermData]
	[ChatsSortTermWithParticipantTwoNameTermData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<ChatsSortTerm> transformer, ISortEnumTermTransformer<Chat> termTransformer)
	{
		// Arrange
		var sortingQuery = _sortingQueryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(_invertedFilterQuery, sortingQuery, _paginationQuery, _invertedCurrentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(_invertedFilterQuery, sortingQuery, _paginationQuery, _invertedCurrentUserQuery, ParticipantTwo, Chats, termTransformer);
	}
}
