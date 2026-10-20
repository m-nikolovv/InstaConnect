using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessages.Repositories;

public class GetChatMessageByIdQueryRepositoryUnitTests : BaseChatMessageInfrastructureQueryUnitTest
{
	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly ChatInclude _include;
	private readonly ChatMessageInclude _messageInclude;

	private readonly ChatMessageQueryRepository _repository;

	public GetChatMessageByIdQueryRepositoryUnitTests()
	{
		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(ParticipantOne);
		_currentUserQuery = _currentUserQueryBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();
		_messageInclude = MessageIncludeBuilderFactory.Create().WithSender().WithChat(_include).WithChatMessageImages().Build();

		_repository = new(Collection, IncludeBuilderFactory, MessageIncludeBuilderFactory);

		Collection.SetupAggregateFluent(ChatMessageId, _currentUserQuery, Fluent);
		Fluent.SetupApplyIncludes(ChatMessageId, _currentUserQuery, _messageInclude);
		Fluent.SetupMatch(ChatMessageId, _currentUserQuery);
		Fluent.SetupProjectToFullResponse(ChatMessageId, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupFirstOrDefaultAsync(ChatMessageId, _currentUserQuery, ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessageId, _currentUserQuery, ChatMessage);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenQueryIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(ChatMessageId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentApplyIncludes_WhenQueryIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(ChatMessageId, _currentUserQuery, _messageInclude);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenQueryIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(ChatMessageId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenQueryIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(ChatMessageId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenQueryIsValid()
	{
		// Act
		await _repository.GetByIdAsync(ChatMessageId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(ChatMessageId, _currentUserQuery, CancellationToken);
	}
}
