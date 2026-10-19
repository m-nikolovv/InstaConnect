using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Domain.Tests.Integration.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.DataAttributes.SortOrder;
using InstaConnect.Chats.Tests.Features.Chats.DataAttributes.SortTerm;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Chats.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Chats.Tests.Features.Users.Utilities;
using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.Chats.Services;

public class GetAllChatsQueryServiceIntegrationTests : BaseChatDomainQueryIntegrationTest
{
	private readonly GetAllChatsQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllChatsQueryBuilder _queryBuilder;
	private readonly GetAllChatsQuery _query;

	private readonly GetAllChatsQueryBuilder _invertedQueryBuilder;
	private readonly GetAllChatsQuery _invertedQuery;

	public GetAllChatsQueryServiceIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Chat);
		_query = _queryBuilder.Build();

		_invertedQueryBuilder = _queryBuilderFactory.Create(Chat).WithCurrentUserId(ParticipantTwoId).WithParticipantTwoName(ParticipantOne.Name);
		_invertedQuery = _invertedQueryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Chats, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowUserNotFoundException_WhenParticipantOneIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ParticipantOne, CancellationToken);

		// Assert
		await Service.ShouldThrowParticipantOneNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, ParticipantOne, Chats);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndParticipantTwoNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithParticipantTwoName(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, ParticipantOne, Chats);
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
		response.ShouldSatisfy(query, ParticipantOne, Chats);
	}

	[Theory]
	[ChatsSortOrderWithAscendingTermData]
	[ChatsSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Chat> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, ParticipantOne, Chats, termTransformer);
	}

	[Theory]
	[ChatsSortTermWithCreatedAtTermData]
	[ChatsSortTermWithParticipantTwoNameTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<ChatsSortTerm> transformer, ISortEnumTermTransformer<Chat> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, ParticipantOne, Chats, termTransformer);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetAllAsync(_invertedQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(_invertedQuery, ParticipantTwo, Chats);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndParticipantTwoNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedQuery = _invertedQueryBuilder.WithParticipantTwoName(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(invertedQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedQuery, ParticipantTwo, Chats);
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
		response.ShouldSatisfyInverted(invertedQuery, ParticipantTwo, Chats);
	}

	[Theory]
	[ChatsSortOrderWithAscendingTermData]
	[ChatsSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Chat> termTransformer)
	{
		// Arrange
		var invertedQuery = _invertedQueryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(invertedQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedQuery, ParticipantTwo, Chats, termTransformer);
	}

	[Theory]
	[ChatsSortTermWithCreatedAtTermData]
	[ChatsSortTermWithParticipantTwoNameTermData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<ChatsSortTerm> transformer, ISortEnumTermTransformer<Chat> termTransformer)
	{
		// Arrange
		var invertedQuery = _invertedQueryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(invertedQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedQuery, ParticipantTwo, Chats, termTransformer);
	}
}
