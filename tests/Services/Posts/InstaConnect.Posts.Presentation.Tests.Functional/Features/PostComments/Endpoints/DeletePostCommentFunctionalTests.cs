using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostComments.Endpoints;

public class DeletePostCommentFunctionalTests : BasePostCommentPresentationCommandFunctionalTest
{
	private readonly DeletePostCommentApiRequestBuilderFactory _requestBuilderFactory;
	private readonly DeletePostCommentApiRequestBuilder _requestBuilder;
	private readonly DeletePostCommentApiRequest _request;

	public DeletePostCommentFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
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

	[Fact]
	public async Task DeleteAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await CommentApiClient.DeleteUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[PostIdTooShortData]
	[PostIdTooLongData]
	public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await CommentApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostIdTooShortWithMessageData]
	[PostIdTooLongWithMessageData]
	public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await CommentApiClient.DeleteProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(request, messageTransformer);
	}

	[Theory]
	[PostCommentIdTooShortData]
	[PostCommentIdTooLongData]
	public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenCommentIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await CommentApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostCommentIdTooShortWithMessageData]
	[PostCommentIdTooLongWithMessageData]
	public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenCommentIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await CommentApiClient.DeleteProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCommentId(request, messageTransformer);
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await CommentApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await CommentApiClient.DeleteProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForUserId(request, messageTransformer);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Act
		var response = await CommentApiClient.DeleteStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task DeleteAsync_ShouldHavePostNotFoundProblemDetails_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Act
		var response = await CommentApiClient.DeleteProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostNotFound(_request);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenPostCommentNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Act
		var response = await CommentApiClient.DeleteStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task DeleteAsync_ShouldHavePostCommentNotFoundProblemDetails_WhenPostCommentNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Act
		var response = await CommentApiClient.DeleteProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostCommentNotFound(_request);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveForbiddenStatusCode_WhenPostCommentForbidden()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithUserId(user.Id).Build();

		// Act
		var response = await CommentApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeForbidden();
	}

	[Fact]
	public async Task DeleteAsync_ShouldHavePostCommentForbiddenProblemDetails_WhenPostCommentForbidden()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithUserId(user.Id).Build();

		// Act
		var response = await CommentApiClient.DeleteProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostCommentForbidden(request);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await CommentApiClient.DeleteStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await CommentApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await CommentApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await CommentApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostComment_WhenRequestIsValid()
	{
		// Act
		await CommentApiClient.DeleteAsync(_request, CancellationToken);
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
		await CommentApiClient.DeleteAsync(request, CancellationToken);
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
		await CommentApiClient.DeleteAsync(request, CancellationToken);
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
		await CommentApiClient.DeleteAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(PostCommentId, CancellationToken);

		// Assert
		postComment.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishPostCommentDeletedEvent_WhenRequestIsValid()
	{
		// Act
		await CommentApiClient.DeleteAsync(_request, CancellationToken);

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
		await CommentApiClient.DeleteAsync(request, CancellationToken);

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
		await CommentApiClient.DeleteAsync(request, CancellationToken);

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
		await CommentApiClient.DeleteAsync(request, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, PostComment);
	}
}
