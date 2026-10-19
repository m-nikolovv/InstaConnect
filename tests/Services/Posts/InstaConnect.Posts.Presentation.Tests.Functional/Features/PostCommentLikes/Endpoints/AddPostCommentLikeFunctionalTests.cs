namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostCommentLikes.Endpoints;

public class AddPostCommentLikeFunctionalTests : BasePostCommentLikePresentationCommandFunctionalTest
{
	private readonly AddPostCommentLikeApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddPostCommentLikeApiRequestBuilder _requestBuilder;
	private readonly AddPostCommentLikeApiRequest _request;

	public AddPostCommentLikeFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostComment, User);
		_request = _requestBuilder.Build();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await CommentLikeApiClient.AddUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[PostIdTooShortData]
	[PostIdTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostIdTooShortWithMessageData]
	[PostIdTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(request, messageTransformer);
	}

	[Theory]
	[PostCommentIdTooShortData]
	[PostCommentIdTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenCommentIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostCommentIdTooShortWithMessageData]
	[PostCommentIdTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenCommentIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCommentId(request, messageTransformer);
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForUserId(request, messageTransformer);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Act
		var response = await CommentLikeApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task AddAsync_ShouldHavePostNotFoundProblemDetails_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Act
		var response = await CommentLikeApiClient.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostNotFound(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenPostCommentNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Act
		var response = await CommentLikeApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task AddAsync_ShouldHavePostCommentNotFoundProblemDetails_WhenPostCommentNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Act
		var response = await CommentLikeApiClient.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostCommentNotFound(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await CommentLikeApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await CommentLikeApiClient.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNotFound(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPostCommentLikeAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(PostCommentLike, CancellationToken);

		// Act
		var response = await CommentLikeApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPostCommentLikeAlreadyExistsAndIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(PostCommentLike, CancellationToken);
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPostCommentLikeAlreadyExistsAndCommentIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(PostCommentLike, CancellationToken);
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPostCommentLikeAlreadyExistsAndUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(PostCommentLike, CancellationToken);
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task AddAsync_ShouldHavePostCommentLikeAlreadyExistsProblemDetails_WhenPostCommentLikeAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(PostCommentLike, CancellationToken);

		// Act
		var response = await CommentLikeApiClient.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostCommentLikeAlreadyExists(_request);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldHavePostCommentLikeAlreadyExistsProblemDetails_WhenPostCommentLikeAlreadyExistsAndIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(PostCommentLike, CancellationToken);
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostCommentLikeAlreadyExists(request);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldHavePostCommentLikeAlreadyExistsProblemDetails_WhenPostCommentLikeAlreadyExistsAndCommentIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(PostCommentLike, CancellationToken);
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostCommentLikeAlreadyExists(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHavePostCommentLikeAlreadyExistsProblemDetails_WhenPostCommentLikeAlreadyExistsAndUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(PostCommentLike, CancellationToken);
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostCommentLikeAlreadyExists(request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await CommentLikeApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await CommentLikeApiClient.AddAsync(_request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, postCommentLike);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.AddAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, postCommentLike);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.AddAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, postCommentLike);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.AddAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, postCommentLike);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenRequestIsValid()
	{
		// Act
		var response = await CommentLikeApiClient.AddAsync(_request, CancellationToken);
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
		var response = await CommentLikeApiClient.AddAsync(request, CancellationToken);
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
		var response = await CommentLikeApiClient.AddAsync(request, CancellationToken);
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
		var response = await CommentLikeApiClient.AddAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await CommentLikeApiClient.AddAsync(_request, CancellationToken);
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
		var response = await CommentLikeApiClient.AddAsync(request, CancellationToken);
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
		var response = await CommentLikeApiClient.AddAsync(request, CancellationToken);
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
		var response = await CommentLikeApiClient.AddAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentLikeEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, postCommentLike);
	}
}
