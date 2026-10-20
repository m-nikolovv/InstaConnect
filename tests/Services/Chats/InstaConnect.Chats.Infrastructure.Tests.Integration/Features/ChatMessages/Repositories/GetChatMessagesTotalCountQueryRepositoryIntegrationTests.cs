using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Builders;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Repositories;

public class GetChatMessagesTotalCountQueryRepositoryIntegrationTests : BaseChatMessageInfrastructureQueryIntegrationTest
{
	private readonly ChatMessagesFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly ChatMessagesFilterQueryBuilder _filterQueryBuilder;
	private readonly ChatMessagesFilterQuery _filterQuery;

	private readonly ChatMessagesFilterQueryBuilder _invertedFilterQueryBuilder;
	private readonly ChatMessagesFilterQuery _invertedFilterQuery;

	public GetChatMessagesTotalCountQueryRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(ChatMessage);
		_filterQuery = _filterQueryBuilder.Build();

		_invertedFilterQueryBuilder = _filterQueryBuilderFactory.Create(ChatMessage).WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		_invertedFilterQuery = _invertedFilterQueryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ChatMessages, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, ChatMessages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountAsync(filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, ChatMessages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountAsync(filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, ChatMessages);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenInvertedQueryIsValid()
	{
		// Act
		var response = await Repository.GetTotalCountAsync(_invertedFilterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_invertedFilterQuery, ChatMessages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenInvertedQueryAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedFilterQuery = _invertedFilterQueryBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountAsync(invertedFilterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedFilterQuery, ChatMessages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenInvertedQueryAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedFilterQuery = _invertedFilterQueryBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountAsync(invertedFilterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedFilterQuery, ChatMessages);
	}
}
