namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostComments.Controllers;

public class UpdatePostCommentControllerIntegrationTests : BasePostCommentPresentationCommandIntegrationTest
{
	private readonly UpdatePostCommentApiRequestBuilderFactory _requestBuilderFactory;
	private readonly UpdatePostCommentApiRequestBuilder _requestBuilder;
	private readonly UpdatePostCommentApiRequest _request;

	public UpdatePostCommentControllerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostComment);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(PostComment, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentImages, CancellationToken);
	}

	[Theory]
	[PostIdNullWithMessageData]
	[PostIdEmptyWithMessageData]
	[PostIdTooShortWithMessageData]
	[PostIdTooLongWithMessageData]
	public async Task UpdateAsync_ShouldThrowValidationException_WhenIdIsInvalid(
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
	public async Task UpdateAsync_ShouldThrowValidationException_WhenCommentIdIsInvalid(
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
	public async Task UpdateAsync_ShouldThrowValidationException_WhenUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForUserIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[PostCommentContentNullWithMessageData]
	[PostCommentContentEmptyWithMessageData]
	[PostCommentContentTooShortWithMessageData]
	[PostCommentContentTooLongWithMessageData]
	public async Task UpdateAsync_ShouldThrowValidationException_WhenContentIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithContent(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForContentAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Assert
		await Controller.ShouldThrowPostNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Assert
		await Controller.ShouldThrowPostCommentNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostCommentForbiddenException_WhenPostCommentForbidden()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithUserId(user.Id).Build();

		// Assert
		await Controller.ShouldThrowPostCommentForbiddenExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.UpdateAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnOkStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.UpdateAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnOkStatusCode_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Controller.UpdateAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnOkStatusCode_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Controller.UpdateAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnOkResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.UpdateAsync(_request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, postComment);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnOkResponse_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.UpdateAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, postComment);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnOkResponse_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Controller.UpdateAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, postComment);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnOkResponse_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Controller.UpdateAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, postComment);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdatePostComment_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.UpdateAsync(_request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(_request);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdatePostComment_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.UpdateAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(request);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdatePostComment_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Controller.UpdateAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdatePostComment_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Controller.UpdateAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(request);
	}

	[Fact]
	public async Task UpdateAsync_ShouldPublishPostCommentUpdatedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.UpdateAsync(_request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, postComment);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishPostCommentUpdatedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.UpdateAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, postComment);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishPostCommentUpdatedEvent_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Controller.UpdateAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, postComment);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishPostCommentUpdatedEvent_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Controller.UpdateAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, postComment);
	}
}
