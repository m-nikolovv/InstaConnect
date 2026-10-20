using InstaConnect.Chats.Domain.Features.Chats.Helpers;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Domain.Tests.Unit.Features.Chats.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.Chats.Services;

public class GetAllChatsQueryServiceUnitTests : BaseChatDomainQueryUnitTest
{
	private readonly GetAllChatsQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllChatsQueryBuilder _queryBuilder;
	private readonly GetAllChatsQuery _query;

	private readonly ChatQueryService _service;

	public GetAllChatsQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Chat);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CollectionResponseFactory);

		UserRepository.SetupGetByIdAsync(_query, ParticipantOne, CancellationToken);
		Repository.SetupGetAllAsync(_query, Chats, CancellationToken);
		Repository.SetupGetTotalCountAsync(_query, Chats, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowParticipantOneNotFoundException_WhenParticipantOneNotFound()
	{
		// Arrange
		UserRepository.RemoveGetByIdAsync(_query, ParticipantOne, CancellationToken);

		// Assert
		await _service.ShouldThrowParticipantOneNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, ParticipantOne, Chats);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneGetByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheRepositoryGetAllAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetAllAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheRepositoryGetTotalCountAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetTotalCountAsync(_query, CancellationToken);
	}
}
