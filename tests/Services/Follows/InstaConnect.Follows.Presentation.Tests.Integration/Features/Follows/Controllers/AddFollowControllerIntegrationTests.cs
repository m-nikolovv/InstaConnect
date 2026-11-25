using InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Integration.Features.Follows.Controllers;

public class AddFollowControllerIntegrationTests : BaseFollowPresentationCommandIntegrationTest
{
	private readonly AddFollowApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddFollowApiRequestBuilder _requestBuilder;
	private readonly AddFollowApiRequest _request;

	public AddFollowControllerIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Follower, Following);
		_request = _requestBuilder.Build();
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task AddAsync_ShouldThrowValidationException_WhenFollowerIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForFollowerIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task AddAsync_ShouldThrowValidationException_WhenFollowingIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForFollowingIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowFollowerNotFoundException_WhenFollowerNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Follower, CancellationToken);

		// Assert
		await Controller.ShouldThrowFollowerNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowFollowingNotFoundException_WhenFollowingNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Following, CancellationToken);

		// Assert
		await Controller.ShouldThrowFollowingNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowFollowAlreadyExistsException_WhenFollowAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);

		// Assert
		await Controller.ShouldThrowFollowAlreadyExistsExceptionAsync(_request, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowFollowAlreadyExistsException_WhenFollowAlreadyExistsAndFollowerIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Assert
		await Controller.ShouldThrowFollowAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowFollowAlreadyExistsException_WhenFollowAlreadyExistsAndFollowingIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Assert
		await Controller.ShouldThrowFollowAlreadyExistsExceptionAsync(request, CancellationToken);
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
	public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
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
		var response = await Controller.AddAsync(request, CancellationToken);
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
		var response = await Controller.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, follow);
	}

	[Fact]
	public async Task AddAsync_ShouldAddFollow_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
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
		var response = await Controller.AddAsync(request, CancellationToken);
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
		var response = await Controller.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		follow.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishFollowAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
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
		var response = await Controller.AddAsync(request, CancellationToken);
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
		var response = await Controller.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, follow);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishFollowAddedNotification_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
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
		var response = await Controller.AddAsync(request, CancellationToken);
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
		var response = await Controller.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var notificationRequest = await NotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, follow);
	}
}
