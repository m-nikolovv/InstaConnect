namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostCommentLikes.Controllers;

public class AddPostCommentLikeControllerIntegrationTests : BasePostCommentLikePresentationCommandIntegrationTest
{
	private readonly AddPostCommentLikeApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddPostCommentLikeApiRequestBuilder _requestBuilder;
	private readonly AddPostCommentLikeApiRequest _request;

	public AddPostCommentLikeControllerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostComment, User);
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
	[PostCommentIdNullWithMessageData]
	[PostCommentIdEmptyWithMessageData]
	[PostCommentIdTooShortWithMessageData]
	[PostCommentIdTooLongWithMessageData]
	public async Task AddAsync_ShouldThrowValidationException_WhenCommentIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForCommentIdAsync(
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
	public async Task AddAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Assert
		await Controller.ShouldThrowPostCommentNotFoundExceptionAsync(_request, CancellationToken);
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
	public async Task AddAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(PostCommentLike, CancellationToken);

		// Assert
		await Controller.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(_request, CancellationToken);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExistsAndIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(PostCommentLike, CancellationToken);
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Controller.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExistsAndCommentIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(PostCommentLike, CancellationToken);
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Assert
		await Controller.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExistsAndUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(PostCommentLike, CancellationToken);
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Assert
		await Controller.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(request, CancellationToken);
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
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

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
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, postCommentLike);
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
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, postCommentLike);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnOkResponse_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, postCommentLike);
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
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, postCommentLike);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(_request);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(request);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentLikeEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, postCommentLike);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentLikeEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, postCommentLike);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentLikeEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, postCommentLike);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentLikeEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, postCommentLike);
	}
}
