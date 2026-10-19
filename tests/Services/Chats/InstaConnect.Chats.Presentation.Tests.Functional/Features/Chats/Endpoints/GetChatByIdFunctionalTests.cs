namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.Chats.Endpoints;

public class GetChatByIdFunctionalTests : BaseChatPresentationQueryFunctionalTest
{
	private readonly GetChatByIdApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetChatByIdApiRequestBuilder _requestBuilder;
	private readonly GetChatByIdApiRequest _request;

	private readonly GetChatByIdApiRequestBuilder _invertedRequestBuilder;
	private readonly GetChatByIdApiRequest _invertedRequest;

	public GetChatByIdFunctionalTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Chat);
		_request = _requestBuilder.Build();

		_invertedRequestBuilder = _requestBuilderFactory.Create(Chat).WithCurrentUserId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		_invertedRequest = _invertedRequestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Chat, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await ApiClient.GetByIdUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.GetByIdProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForParticipantTwoId(request, messageTransformer);
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await ApiClient.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await ApiClient.GetByIdProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCurrentUserId(request, messageTransformer);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenChatNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Act
		var response = await ApiClient.GetByIdStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveChatNotFoundProblemDetails_WhenChatNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Act
		var response = await ApiClient.GetByIdProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyChatNotFound(_request);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.GetByIdStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await ApiClient.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.GetByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, Chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.GetByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, Chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await ApiClient.GetByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, Chat);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveInvertedOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.GetByIdStatusCodeAsync(_invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.GetByIdStatusCodeAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await ApiClient.GetByIdStatusCodeAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveInvertedResponse_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.GetByIdAsync(_invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(_invertedRequest, Chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveInvertedResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.GetByIdAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedRequest, Chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnInvertedResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await ApiClient.GetByIdAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedRequest, Chat);
	}
}
