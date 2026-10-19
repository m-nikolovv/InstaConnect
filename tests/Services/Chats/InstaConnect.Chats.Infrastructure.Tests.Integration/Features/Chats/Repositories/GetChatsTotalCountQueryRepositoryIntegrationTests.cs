using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Repositories;

public class GetChatsTotalCountQueryRepositoryIntegrationTests : BaseChatInfrastructureQueryIntegrationTest
{
	private readonly ChatsFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly ChatsFilterQueryBuilder _filterQueryBuilder;
	private readonly ChatsFilterQuery _filterQuery;

	private readonly ChatsFilterQueryBuilder _invertedFilterQueryBuilder;
	private readonly ChatsFilterQuery _invertedFilterQuery;

	public GetChatsTotalCountQueryRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(Chat);
		_filterQuery = _filterQueryBuilder.Build();

		_invertedFilterQueryBuilder = _filterQueryBuilderFactory.Create(Chat).WithParticipantOneId(ParticipantTwoId).WithParticipantTwoName(ParticipantOne.Name);
		_invertedFilterQuery = _invertedFilterQueryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Chats, CancellationToken);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, Chats);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryAndParticipantTwoNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithParticipantTwoName(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountAsync(filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, Chats);
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
		response.ShouldSatisfy(filterQuery, Chats);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenInvertedQueryIsValid()
	{
		// Act
		var response = await Repository.GetTotalCountAsync(_invertedFilterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_invertedFilterQuery, Chats);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenInvertedQueryAndParticipantTwoNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedFilterQuery = _invertedFilterQueryBuilder.WithParticipantTwoName(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountAsync(invertedFilterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedFilterQuery, Chats);
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
		response.ShouldSatisfy(invertedFilterQuery, Chats);
	}
}
