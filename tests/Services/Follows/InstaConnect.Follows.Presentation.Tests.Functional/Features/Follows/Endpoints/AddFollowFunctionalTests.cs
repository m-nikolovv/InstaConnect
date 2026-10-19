namespace InstaConnect.Follows.Presentation.Tests.Functional.Features.Follows.Endpoints;

public class AddFollowFunctionalTests : BaseFollowPresentationCommandFunctionalTest
{
	private readonly AddFollowApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddFollowApiRequestBuilder _requestBuilder;
	private readonly AddFollowApiRequest _request;

	public AddFollowFunctionalTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Follower, Following);
		_request = _requestBuilder.Build();
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
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenFollowerIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenFollowerIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForFollowerId(request, messageTransformer);
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenFollowingIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenFollowingIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForFollowingId(request, messageTransformer);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenFollowerNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Follower, CancellationToken);

		// Act
		var response = await ApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveFollowerNotFoundProblemDetails_WhenFollowerNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Follower, CancellationToken);

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyFollowerNotFound(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenFollowingNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Following, CancellationToken);

		// Act
		var response = await ApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveFollowingNotFoundProblemDetails_WhenFollowingNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Following, CancellationToken);

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyFollowingNotFound(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenFollowAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);

		// Act
		var response = await ApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenFollowAlreadyExistsAndFollowerIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenFollowAlreadyExistsAndFollowingIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveFollowAlreadyExistsProblemDetails_WhenFollowAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyFollowAlreadyExists(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveFollowAlreadyExistsProblemDetails_WhenFollowAlreadyExistsAndFollowerIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyFollowAlreadyExists(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveFollowAlreadyExistsProblemDetails_WhenFollowAlreadyExistsAndFollowingIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyFollowAlreadyExists(request);
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
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

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
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, follow);
	}

	[Fact]
	public async Task AddAsync_ShouldAddFollow_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		follow.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddFollow_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		follow.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddFollow_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		follow.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishFollowAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishFollowAddedEvent_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishFollowAddedEvent_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, follow);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishFollowAddedNotification_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await NotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(_request, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishFollowAddedNotification_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await NotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishFollowAddedNotification_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await NotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, follow);
	}
}
