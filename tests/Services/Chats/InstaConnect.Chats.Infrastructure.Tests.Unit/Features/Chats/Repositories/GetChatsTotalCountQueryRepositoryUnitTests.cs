using InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Builders;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Chats.Repositories;

public class GetChatsTotalCountQueryRepositoryUnitTests : BaseChatInfrastructureQueryUnitTest
{
	private readonly ChatsFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly ChatsFilterQueryBuilder _filterQueryBuilder;
	private readonly ChatsFilterQuery _filterQuery;

	private readonly ChatQueryRepository _repository;

	public GetChatsTotalCountQueryRepositoryUnitTests()
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(Chat);
		_filterQuery = _filterQueryBuilder.Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_filterQuery, Fluent);
		Fluent.SetupMatch(_filterQuery);
		Fluent.SetupGetCountAsync(_filterQuery, Chats, CancellationToken);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, Chats);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldCallTheCollectionAggregateFluent_WhenQueryIsValid()
	{
		// Act
		await _repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_filterQuery);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldCallTheFluentMatch_WhenQueryIsValid()
	{
		// Act
		await _repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_filterQuery);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldCallTheFluentGetCountAsync_WhenQueryIsValid()
	{
		// Act
		await _repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneGetCountAsync(_filterQuery, CancellationToken);
	}
}
