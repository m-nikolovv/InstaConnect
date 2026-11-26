using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Domain.Tests.Integration.Features.Chats.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.Chats.Services;

public class GetChatByIdQueryServiceIntegrationTests : BaseChatDomainQueryIntegrationTest
{
	private readonly GetChatByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly GetChatByIdQueryBuilder _queryBuilder;
	private readonly GetChatByIdQuery _query;

	private readonly GetChatByIdQueryBuilder _invertedQueryBuilder;
	private readonly GetChatByIdQuery _invertedQuery;

	public GetChatByIdQueryServiceIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Chat, UserId);
		_query = _queryBuilder.Build();

		_invertedQueryBuilder = _queryBuilderFactory.Create(Chat, UserId).WithCurrentUserId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		_invertedQuery = _invertedQueryBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupGetByIdAsync(_query, Chat, CancellationToken);
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
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, Chat);
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
		response.ShouldSatisfy(query, Chat);
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
		response.ShouldSatisfy(query, Chat);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCacheChat_WhenQueryIsValid()
	{
		// Act
		await Service.GetByIdAsync(_query, CancellationToken);
		var cachedChat = await ServiceScope.GetChatCacheByIdAsync(_query, CancellationToken);

		// Assert
		cachedChat.ShouldSatisfy(_query, Chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCacheChat_WhenQueryAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Service.GetByIdAsync(query, CancellationToken);
		var cachedChat = await ServiceScope.GetChatCacheByIdAsync(query, CancellationToken);

		// Assert
		cachedChat.ShouldSatisfy(query, Chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCacheChat_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		await Service.GetByIdAsync(query, CancellationToken);
		var cachedChat = await ServiceScope.GetChatCacheByIdAsync(query, CancellationToken);

		// Assert
		cachedChat.ShouldSatisfy(query, Chat);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnInvertedResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetByIdAsync(_invertedQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(_invertedQuery, Chat);
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
		response.ShouldSatisfyInverted(invertedQuery, Chat);
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
		response.ShouldSatisfyInverted(invertedQuery, Chat);
	}
}
