namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.Chats.Endpoints;

public class AddChatFunctionalTests : BaseChatPresentationCommandFunctionalTest
{
	private readonly AddChatApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddChatApiRequestBuilder _requestBuilder;
	private readonly AddChatApiRequest _request;

	private readonly AddChatApiRequestBuilder _invertedRequestBuilder;
	private readonly AddChatApiRequest _invertedRequest;

	public AddChatFunctionalTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ParticipantOne, ParticipantTwo);
		_request = _requestBuilder.Build();

		_invertedRequestBuilder = _requestBuilderFactory.Create(ParticipantOne, ParticipantTwo).WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		_invertedRequest = _invertedRequestBuilder.Build();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await ApiClient.AddUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenParticipantOneIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantOneIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForParticipantOneId(request, messageTransformer);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForParticipantTwoId(request, messageTransformer);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenParticipantOneNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ParticipantOne, CancellationToken);

		// Act
		var response = await ApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveParticipantOneNotFoundProblemDetails_WhenParticipantOneNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ParticipantOne, CancellationToken);

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyParticipantOneNotFound(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenParticipantTwoNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ParticipantTwo, CancellationToken);

		// Act
		var response = await ApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveParticipantTwoNotFoundProblemDetails_WhenParticipantTwoNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ParticipantTwo, CancellationToken);

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyParticipantTwoNotFound(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenChatAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);

		// Act
		var response = await ApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveChatAlreadyExistsProblemDetails_WhenChatAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyChatAlreadyExists(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenChatAlreadyExistsAndParticipantOneIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveChatAlreadyExistsProblemDetails_WhenChatAlreadyExistsAndParticipantOneIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyChatAlreadyExists(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenChatAlreadyExistsAndParticipantTwoIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveChatAlreadyExistsProblemDetails_WhenChatAlreadyExistsAndParticipantTwoIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyChatAlreadyExists(request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenInvertedChatAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);

		// Act
		var response = await ApiClient.AddStatusCodeAsync(_invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveChatAlreadyExistsProblemDetails_WhenInvertedChatAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(_invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyChatAlreadyExists(_invertedRequest);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenInvertedChatAlreadyExistsAndParticipantOneIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveChatAlreadyExistsProblemDetails_WhenInvertedChatAlreadyExistsAndParticipantOneIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyChatAlreadyExists(invertedRequest);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenInvertedChatAlreadyExistsAndParticipantTwoIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveChatAlreadyExistsProblemDetails_WhenInvertedChatAlreadyExistsAndParticipantTwoIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyChatAlreadyExists(invertedRequest);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, chat);
	}

	[Fact]
	public async Task AddAsync_ShouldAddChat_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
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
		var response = await ApiClient.AddAsync(request, CancellationToken);
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
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chat.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishChatAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
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
		var response = await ApiClient.AddAsync(request, CancellationToken);
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
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, chat);
	}
}
