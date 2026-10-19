namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostLikes.Controllers;

public class AddPostLikeControllerIntegrationTests : BasePostLikePresentationCommandIntegrationTest
{
	private readonly AddPostLikeApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddPostLikeApiRequestBuilder _requestBuilder;
	private readonly AddPostLikeApiRequest _request;

	public AddPostLikeControllerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post, User);
		_request = _requestBuilder.Build();
	}

	[Theory]
	[PostIdNullWithMessageData]
	[PostIdEmptyWithMessageData]
	[PostIdTooShortWithMessageData]
	[PostIdTooLongWithMessageData]
	public async Task AddAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task AddAsync_ShouldThrowValidationException_WhenUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForUserIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Assert
		await Controller.ShouldThrowPostNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Controller.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowPostLikeAlreadyExistsException_WhenPostLikeAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(PostLike, CancellationToken);

		// Assert
		await Controller.ShouldThrowPostLikeAlreadyExistsExceptionAsync(_request, CancellationToken);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowPostLikeAlreadyExistsException_WhenPostLikeAlreadyExistsAndIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(PostLike, CancellationToken);
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Controller.ShouldThrowPostLikeAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowPostLikeAlreadyExistsException_WhenPostLikeAlreadyExistsAndUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(PostLike, CancellationToken);
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Assert
		await Controller.ShouldThrowPostLikeAlreadyExistsExceptionAsync(request, CancellationToken);
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
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

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
		var postLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, postLike);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnOkResponse_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, postLike);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnOkResponse_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, postLike);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostLike_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postLike.ShouldSatisfy(_request);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostLike_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postLike.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostLike_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postLike.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishPostLikeAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await LikeEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, postLike);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostLikeAddedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await LikeEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, postLike);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostLikeAddedEvent_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await LikeEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, postLike);
	}
}
