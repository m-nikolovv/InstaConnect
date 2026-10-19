namespace InstaConnect.Follows.Presentation.Tests.Integration.Features.Follows.Controllers;

public class DeleteFollowControllerIntegrationTests : BaseFollowPresentationCommandIntegrationTest
{
	private readonly DeleteFollowApiRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteFollowApiRequestBuilder _requestBuilder;
	private readonly DeleteFollowApiRequest _request;

	public DeleteFollowControllerIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Follow);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Follow, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task DeleteAsync_ShouldThrowValidationException_WhenFollowerIdIsInvalid(
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
	public async Task DeleteAsync_ShouldThrowValidationException_WhenFollowingIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForFollowingIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowFollowNotFoundException_WhenFollowNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Follow, CancellationToken);

		// Assert
		await Controller.ShouldThrowFollowNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.DeleteAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Controller.DeleteAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Controller.DeleteAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteFollow_WhenRequestIsValid()
	{
		// Act
		await Controller.DeleteAsync(_request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(FollowId, CancellationToken);

		// Assert
		follow.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteFollow_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		await Controller.DeleteAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(FollowId, CancellationToken);

		// Assert
		follow.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteFollow_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		await Controller.DeleteAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(FollowId, CancellationToken);

		// Assert
		follow.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishFollowDeletedEvent_WhenRequestIsValid()
	{
		// Act
		await Controller.DeleteAsync(_request, CancellationToken);

		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, Follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishFollowDeletedEvent_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		await Controller.DeleteAsync(request, CancellationToken);

		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, Follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishFollowDeletedEvent_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		await Controller.DeleteAsync(request, CancellationToken);

		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, Follow);
	}
}
