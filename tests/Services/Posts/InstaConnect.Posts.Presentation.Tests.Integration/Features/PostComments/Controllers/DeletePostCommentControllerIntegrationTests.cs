namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostComments.Controllers;

public class DeletePostCommentControllerIntegrationTests : BasePostCommentPresentationCommandIntegrationTest
{
	private readonly DeletePostCommentApiRequestBuilderFactory _requestBuilderFactory;
	private readonly DeletePostCommentApiRequestBuilder _requestBuilder;
	private readonly DeletePostCommentApiRequest _request;

	public DeletePostCommentControllerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
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
	public async Task DeleteAsync_ShouldThrowValidationException_WhenIdIsInvalid(
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
	public async Task DeleteAsync_ShouldThrowValidationException_WhenCommentIdIsInvalid(
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
	public async Task DeleteAsync_ShouldThrowValidationException_WhenUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForUserIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Assert
		await Controller.ShouldThrowPostNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Assert
		await Controller.ShouldThrowPostCommentNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostCommentForbiddenException_WhenPostCommentForbidden()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithUserId(user.Id).Build();

		// Assert
		await Controller.ShouldThrowPostCommentForbiddenExceptionAsync(request, CancellationToken);
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
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.DeleteAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Controller.DeleteAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Controller.DeleteAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostComment_WhenRequestIsValid()
	{
		// Act
		await Controller.DeleteAsync(_request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(PostCommentId, CancellationToken);

		// Assert
		postComment.ShouldBeNull();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostComment_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Controller.DeleteAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(PostCommentId, CancellationToken);

		// Assert
		postComment.ShouldBeNull();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostComment_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		await Controller.DeleteAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(PostCommentId, CancellationToken);

		// Assert
		postComment.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostComment_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		await Controller.DeleteAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(PostCommentId, CancellationToken);

		// Assert
		postComment.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishPostCommentDeletedEvent_WhenRequestIsValid()
	{
		// Act
		await Controller.DeleteAsync(_request, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, PostComment);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostCommentDeletedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Controller.DeleteAsync(request, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, PostComment);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostCommentDeletedEvent_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		await Controller.DeleteAsync(request, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, PostComment);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostCommentDeletedEvent_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		await Controller.DeleteAsync(request, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, PostComment);
	}
}
