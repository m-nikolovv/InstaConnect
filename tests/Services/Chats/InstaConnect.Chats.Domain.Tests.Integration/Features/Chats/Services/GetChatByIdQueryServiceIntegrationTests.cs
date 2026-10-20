using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Builders;
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
		_queryBuilder = _queryBuilderFactory.Create(Chat);
		_query = _queryBuilder.Build();

		_invertedQueryBuilder = _queryBuilderFactory.Create(Chat).WithCurrentUserId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		_invertedQuery = _invertedQueryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Chat, CancellationToken);
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
