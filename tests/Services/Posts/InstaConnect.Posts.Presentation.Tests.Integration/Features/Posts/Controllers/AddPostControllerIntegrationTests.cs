using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Content;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Images;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Title;

namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.Posts.Controllers;

public class AddPostControllerIntegrationTests : BasePostPresentationCommandIntegrationTest
{
	private readonly AddPostApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddPostApiRequestBuilder _requestBuilder;
	private readonly AddPostApiRequest _request;

	public AddPostControllerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
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
	[PostTitleNullWithMessageData]
	[PostTitleEmptyWithMessageData]
	[PostTitleTooShortWithMessageData]
	[PostTitleTooLongWithMessageData]
	public async Task AddAsync_ShouldThrowValidationException_WhenTitleIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithTitle(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForTitleAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[PostContentNullWithMessageData]
	[PostContentEmptyWithMessageData]
	[PostContentTooShortWithMessageData]
	[PostContentTooLongWithMessageData]
	public async Task AddAsync_ShouldThrowValidationException_WhenContentIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithContent(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForContentAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[PostImagesTooManyWithMessageData]
	[PostImagesTooLargeWithMessageData]
	[PostImagesInvalidContentTypeWithMessageData]
	public async Task AddAsync_ShouldThrowValidationException_WhenImagesAreInvalid(
		IFormFileCollectionTransformer transformer, IFormFileCollectionMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForImagesAsync(
			request, messageTransformer, CancellationToken);
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
	[PostImagesEmptyData]
	[PostImagesJpegData]
	[PostImagesPngData]
	[PostImagesWebpData]
	[PostImagesJpegDifferentCaseData]
	[PostImagesPngDifferentCaseData]
	[PostImagesWebpDifferentCaseData]
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
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, post);
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
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, post);
	}

	[Theory]
	[PostImagesEmptyData]
	[PostImagesJpegData]
	[PostImagesPngData]
	[PostImagesWebpData]
	[PostImagesJpegDifferentCaseData]
	[PostImagesPngDifferentCaseData]
	[PostImagesWebpDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, post);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPost_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPost_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.ShouldSatisfy(request);
	}

	[Theory]
	[PostImagesEmptyData]
	[PostImagesJpegData]
	[PostImagesPngData]
	[PostImagesWebpData]
	[PostImagesJpegDifferentCaseData]
	[PostImagesPngDifferentCaseData]
	[PostImagesWebpDifferentCaseData]
	public async Task AddAsync_ShouldAddPost_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishPostAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, post);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostAddedEvent_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, post);
	}

	[Theory]
	[PostImagesEmptyData]
	[PostImagesJpegData]
	[PostImagesPngData]
	[PostImagesWebpData]
	[PostImagesJpegDifferentCaseData]
	[PostImagesPngDifferentCaseData]
	[PostImagesWebpDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostAddedEvent_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, post);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostImages_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.PostImages.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostImages_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.PostImages.ShouldSatisfy(request);
	}

	[Theory]
	[PostImagesEmptyData]
	public async Task AddAsync_ShouldAddPostImages_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.PostImages.ShouldBeEmpty();
	}
}
