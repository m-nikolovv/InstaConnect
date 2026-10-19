namespace InstaConnect.Follows.Application.Tests.Integration.Features.Follows.Handlers;

public class AddFollowCommandHandlerIntegrationTests : BaseFollowApplicationCommandIntegrationTest
{
	private readonly AddFollowCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddFollowCommandRequestBuilder _requestBuilder;
	private readonly AddFollowCommandRequest _request;

	public AddFollowCommandHandlerIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
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
	public async Task SendAsync_ShouldThrowValidationException_WhenFollowerIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForFollowerIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenFollowingIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForFollowingIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowFollowerNotFoundException_WhenFollowerIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Follower, CancellationToken);

		// Assert
		await Sender.ShouldThrowFollowerNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowFollowingNotFoundException_WhenFollowingIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Following, CancellationToken);

		// Assert
		await Sender.ShouldThrowFollowingNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowFollowAlreadyExistsException_WhenFollowAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);

		// Assert
		await Sender.ShouldThrowFollowAlreadyExistsExceptionAsync(_request, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldThrowFollowAlreadyExistsException_WhenFollowAlreadyExistsAndFollowerIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Assert
		await Sender.ShouldThrowFollowAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldThrowFollowAlreadyExistsException_WhenFollowAlreadyExistsAndFollowingIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Assert
		await Sender.ShouldThrowFollowAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, follow);
	}

	[Fact]
	public async Task SendAsync_ShouldAddFollow_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		follow.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddFollow_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		follow.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddFollow_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		follow.ShouldSatisfy(request);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishFollowAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishFollowAddedEvent_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishFollowAddedEvent_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, follow);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishFollowAddedNotification_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await NotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(_request, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishFollowAddedNotification_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await NotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishFollowAddedNotification_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await NotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, follow);
	}
}
