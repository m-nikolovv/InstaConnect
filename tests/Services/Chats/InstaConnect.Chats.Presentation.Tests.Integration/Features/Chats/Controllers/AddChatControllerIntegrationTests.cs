namespace InstaConnect.Chats.Presentation.Tests.Integration.Features.Chats.Controllers;

public class AddChatControllerIntegrationTests : BaseChatPresentationCommandIntegrationTest
{
	private readonly AddChatApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddChatApiRequestBuilder _requestBuilder;
	private readonly AddChatApiRequest _request;

	private readonly AddChatApiRequestBuilder _invertedRequestBuilder;
	private readonly AddChatApiRequest _invertedRequest;

	public AddChatControllerIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
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
	public async Task AddAsync_ShouldThrowValidationException_WhenParticipantOneIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForParticipantOneIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task AddAsync_ShouldThrowValidationException_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForParticipantTwoIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowParticipantOneNotFoundException_WhenParticipantOneIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ParticipantOne, CancellationToken);

		// Assert
		await Controller.ShouldThrowParticipantOneNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowParticipantTwoNotFoundException_WhenParticipantTwoIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ParticipantTwo, CancellationToken);

		// Assert
		await Controller.ShouldThrowParticipantTwoNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenChatAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);

		// Assert
		await Controller.ShouldThrowChatAlreadyExistsExceptionAsync(_request, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenChatAlreadyExistsAndParticipantOneIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Assert
		await Controller.ShouldThrowChatAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenChatAlreadyExistsAndParticipantTwoIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Assert
		await Controller.ShouldThrowChatAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenInvertedChatAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);

		// Assert
		await Controller.ShouldThrowChatAlreadyExistsExceptionAsync(_invertedRequest, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenInvertedChatAlreadyExistsAndParticipantOneIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Assert
		await Controller.ShouldThrowChatAlreadyExistsExceptionAsync(invertedRequest, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenInvertedChatAlreadyExistsAndParticipantTwoIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Assert
		await Controller.ShouldThrowChatAlreadyExistsExceptionAsync(invertedRequest, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnOkResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnOkResponse_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnOkResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, chat);
	}

	[Fact]
	public async Task AddAsync_ShouldAddChat_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chat.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddChat_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chat.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddChat_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chat.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishChatAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishChatAddedEvent_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishChatAddedEvent_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, chat);
	}
}
