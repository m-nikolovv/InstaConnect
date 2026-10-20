using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Content;
using InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Images;

namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostComments.Controllers;

public class AddPostCommentControllerIntegrationTests : BasePostCommentPresentationCommandIntegrationTest
{
	private readonly AddPostCommentApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddPostCommentApiRequestBuilder _requestBuilder;
	private readonly AddPostCommentApiRequest _request;

	public AddPostCommentControllerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post, User, PostComment.PostCommentImages.Count);
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

	[Theory]
	[PostCommentContentNullWithMessageData]
	[PostCommentContentEmptyWithMessageData]
	[PostCommentContentTooShortWithMessageData]
	[PostCommentContentTooLongWithMessageData]
	public async Task AddAsync_ShouldThrowValidationException_WhenContentIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithContent(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForContentAsync(
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

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

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
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, postComment);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, postComment);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, postComment);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, postComment);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostComment_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(_request);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostComment_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostComment_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(request);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task AddAsync_ShouldAddPostComment_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishPostCommentAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, postComment);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostCommentAddedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, postComment);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostCommentAddedEvent_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, postComment);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task AddAsync_ShouldPublishPostCommentAddedEvent_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, postComment);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostCommentImages_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.PostCommentImages.ShouldSatisfy(_request);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostCommentImages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.PostCommentImages.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostCommentImages_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.PostCommentImages.ShouldSatisfy(request);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task AddAsync_ShouldAddPostCommentImages_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.PostCommentImages.ShouldBeEmpty();
	}
}
