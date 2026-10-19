namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostCommentLikes.Endpoints;

public class GetPostCommentLikeByIdFunctionalTests : BasePostCommentLikePresentationQueryFunctionalTest
{
	private readonly GetPostCommentLikeByIdApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetPostCommentLikeByIdApiRequestBuilder _requestBuilder;
	private readonly GetPostCommentLikeByIdApiRequest _request;

	public GetPostCommentLikeByIdFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(PostCommentLike, CancellationToken);
	}

	[Theory]
	[PostIdTooShortData]
	[PostIdTooLongData]
	public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostIdTooShortWithMessageData]
	[PostIdTooLongWithMessageData]
	public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.GetByIdProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(request, messageTransformer);
	}

	[Theory]
	[PostCommentIdTooShortData]
	[PostCommentIdTooLongData]
	public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenCommentIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostCommentIdTooShortWithMessageData]
	[PostCommentIdTooLongWithMessageData]
	public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenCommentIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.GetByIdProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCommentId(request, messageTransformer);
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.GetByIdProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForUserId(request, messageTransformer);
	}

	[Theory]
	[UserIdTooLongData]
	public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooLongWithMessageData]
	public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.GetByIdProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCurrentUserId(request, messageTransformer);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Act
		var response = await CommentLikeApiClient.GetByIdStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHavePostNotFoundProblemDetails_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Act
		var response = await CommentLikeApiClient.GetByIdProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostNotFound(_request);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenPostCommentNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Act
		var response = await CommentLikeApiClient.GetByIdStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHavePostCommentNotFoundProblemDetails_WhenPostCommentNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Act
		var response = await CommentLikeApiClient.GetByIdProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostCommentNotFound(_request);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenPostCommentLikeNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostCommentLike, CancellationToken);

		// Act
		var response = await CommentLikeApiClient.GetByIdStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHavePostCommentLikeNotFoundProblemDetails_WhenPostCommentLikeNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostCommentLike, CancellationToken);

		// Act
		var response = await CommentLikeApiClient.GetByIdProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostCommentLikeNotFound(_request);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await CommentLikeApiClient.GetByIdStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestIsValid()
	{
		// Act
		var response = await CommentLikeApiClient.GetByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, PostCommentLike);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.GetByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, PostCommentLike);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.GetByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, PostCommentLike);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.GetByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, PostCommentLike);
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await CommentLikeApiClient.GetByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, PostCommentLike);
	}
}
