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
		_queryBuilder = _queryBuilderFactory.Create(ChatMessage);
		_query = _queryBuilder.Build();

		_invertedQueryBuilder = _queryBuilderFactory.Create(ChatMessage).WithCurrentUserId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		_invertedQuery = _invertedQueryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(ChatMessage, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
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
