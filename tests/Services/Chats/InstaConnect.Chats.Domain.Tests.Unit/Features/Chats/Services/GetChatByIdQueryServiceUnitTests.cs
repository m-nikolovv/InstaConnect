using InstaConnect.Chats.Domain.Features.Chats.Helpers;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Domain.Tests.Unit.Features.Chats.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.Chats.Services;

public class GetChatByIdQueryServiceUnitTests : BaseChatDomainQueryUnitTest
{
	private readonly GetChatByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly GetChatByIdQueryBuilder _queryBuilder;
	private readonly GetChatByIdQuery _query;

	private readonly ChatQueryService _service;

	public GetChatByIdQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Chat);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CollectionResponseFactory);

		Repository.SetupGetByIdAsync(_query, Chat, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowChatNotFoundException_WhenChatNotFound()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_query, Chat, CancellationToken);

		// Assert
		await _service.ShouldThrowChatNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, Chat);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_query, CancellationToken);
	}
}
