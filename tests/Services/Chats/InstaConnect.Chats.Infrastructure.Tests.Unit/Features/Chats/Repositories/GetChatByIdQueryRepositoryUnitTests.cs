namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Chats.Repositories;

public class GetChatByIdQueryRepositoryUnitTests : BaseChatInfrastructureQueryUnitTest
{
	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly ChatInclude _include;

	private readonly ChatQueryRepository _repository;

	public GetChatByIdQueryRepositoryUnitTests()
	{
		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(ParticipantOne);
		_currentUserQuery = _currentUserQueryBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(ChatId, _currentUserQuery, Fluent);
		Fluent.SetupApplyIncludes(ChatId, _currentUserQuery, _include);
		Fluent.SetupMatch(ChatId, _currentUserQuery);
		Fluent.SetupProjectToFullResponse(ChatId, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupFirstOrDefaultAsync(ChatId, _currentUserQuery, Chat, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatId, _currentUserQuery, Chat);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenQueryIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ChatId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentApplyIncludes_WhenQueryIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(ChatId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenQueryIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ChatId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenQueryIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(ChatId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenQueryIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(ChatId, _currentUserQuery, CancellationToken);
	}
}
