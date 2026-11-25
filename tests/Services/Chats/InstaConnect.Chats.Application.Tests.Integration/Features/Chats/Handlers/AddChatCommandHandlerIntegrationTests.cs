using InstaConnect.Chats.Application.Features.Chats.Commands.Add;
using InstaConnect.Chats.Application.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Application.Tests.Integration.Features.Chats.Utilities;

namespace InstaConnect.Chats.Application.Tests.Integration.Features.Chats.Handlers;

public class AddChatCommandHandlerIntegrationTests : BaseChatApplicationCommandIntegrationTest
{
	private readonly AddChatCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddChatCommandRequestBuilder _requestBuilder;
	private readonly AddChatCommandRequest _request;

	private readonly AddChatCommandRequestBuilder _invertedRequestBuilder;
	private readonly AddChatCommandRequest _invertedRequest;

	public AddChatCommandHandlerIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ParticipantOne, ParticipantTwo);
		_request = _requestBuilder.Build();

		_invertedRequestBuilder = _requestBuilderFactory.Create(ParticipantOne, ParticipantTwo).WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		_invertedRequest = _invertedRequestBuilder.Build();
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenParticipantOneIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForParticipantOneIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForParticipantTwoIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowParticipantOneNotFoundException_WhenParticipantOneNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ParticipantOne, CancellationToken);

		// Assert
		await Sender.ShouldThrowParticipantOneNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowParticipantTwoNotFoundException_WhenParticipantTwoNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ParticipantTwo, CancellationToken);

		// Assert
		await Sender.ShouldThrowParticipantTwoNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowChatAlreadyExistsException_WhenChatAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);

		// Assert
		await Sender.ShouldThrowChatAlreadyExistsExceptionAsync(_request, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldThrowChatAlreadyExistsException_WhenChatAlreadyExistsAndParticipantOneIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Assert
		await Sender.ShouldThrowChatAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldThrowChatAlreadyExistsException_WhenChatAlreadyExistsAndParticipantTwoIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Assert
		await Sender.ShouldThrowChatAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowChatAlreadyExistsException_WhenInvertedChatAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);

		// Assert
		await Sender.ShouldThrowChatAlreadyExistsExceptionAsync(_invertedRequest, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldThrowChatAlreadyExistsException_WhenInvertedChatAlreadyExistsAndParticipantOneIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Assert
		await Sender.ShouldThrowChatAlreadyExistsExceptionAsync(invertedRequest, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldThrowChatAlreadyExistsException_WhenInvertedChatAlreadyExistsAndParticipantTwoIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Assert
		await Sender.ShouldThrowChatAlreadyExistsExceptionAsync(invertedRequest, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, chat);
	}

	[Fact]
	public async Task SendAsync_ShouldAddChat_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chat.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddChat_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chat.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddChat_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chat.ShouldSatisfy(request);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishChatAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishChatAddedEvent_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishChatAddedEvent_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, chat);
	}
}
