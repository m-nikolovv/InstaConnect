using InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Services;

public class GetAllChatMessagesQueryServiceUnitTests : BaseChatMessageDomainQueryUnitTest
{
	private readonly GetAllChatMessagesQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllChatMessagesQueryBuilder _queryBuilder;
	private readonly GetAllChatMessagesQuery _query;

	private readonly ChatMessageQueryService _service;

	public GetAllChatMessagesQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(ChatMessage);
		_query = _queryBuilder.Build();

		_service = new(Repository, MessageRepository, CollectionResponseFactory);

		Repository.SetupGetByIdAsync(_query, Chat, CancellationToken);
		MessageRepository.SetupGetAllAsync(_query, ChatMessages, CancellationToken);
		MessageRepository.SetupGetTotalCountAsync(_query, ChatMessages, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowChatNotFoundException_WhenChatNotFound()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_query, Chat, CancellationToken);

		// Assert
		await _service.ShouldThrowChatNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, Chat, ChatMessages);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheMessageRepositoryGetAllAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await MessageRepository.ShouldHaveReceivedOneGetAllAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheMessageRepositoryGetTotalCountAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await MessageRepository.ShouldHaveReceivedOneGetTotalCountAsync(_query, CancellationToken);
	}
}
