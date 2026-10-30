using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Content;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Images;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Title;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.Posts.Endpoints;

public class AddPostFunctionalTests : BasePostPresentationCommandFunctionalTest
{
	private readonly AddPostApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddPostApiRequestBuilder _requestBuilder;
	private readonly AddPostApiRequest _request;

	public AddPostFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await ApiClient.AddUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
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
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

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
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForUserId(request, messageTransformer);
	}

	[Theory]
	[PostTitleNullData]
	[PostTitleEmptyData]
	[PostTitleTooShortData]
	[PostTitleTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenTitleIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithTitle(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostTitleNullWithMessageData]
	[PostTitleEmptyWithMessageData]
	[PostTitleTooShortWithMessageData]
	[PostTitleTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenTitleIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithTitle(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForTitle(request, messageTransformer);
	}

	[Theory]
	[PostContentNullData]
	[PostContentEmptyData]
	[PostContentTooShortData]
	[PostContentTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenContentIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithContent(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostContentNullWithMessageData]
	[PostContentEmptyWithMessageData]
	[PostContentTooShortWithMessageData]
	[PostContentTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenContentIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithContent(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForContent(request, messageTransformer);
	}

	[Theory]
	[PostImagesTooManyData]
	[PostImagesTooLargeData]
	[PostImagesInvalidContentTypeData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenImagesAreInvalid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostImagesTooManyWithMessageData]
	[PostImagesTooLargeWithMessageData]
	[PostImagesInvalidContentTypeWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenImagesAreInvalid(
		IFormFileCollectionTransformer transformer, IFormFileCollectionMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForImages(request, messageTransformer);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await ApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNotFound(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddStatusCodeAsync(_request, CancellationToken);

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
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[PostImagesEmptyData]
	[PostImagesJpegData]
	[PostImagesPngData]
	[PostImagesWebpData]
	[PostImagesJpegDifferentCaseData]
	[PostImagesPngDifferentCaseData]
	[PostImagesWebpDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
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
		var response = await ApiClient.AddAsync(request, CancellationToken);
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
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, post);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPost_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
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
		var response = await ApiClient.AddAsync(request, CancellationToken);
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
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishPostAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
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
		var response = await ApiClient.AddAsync(request, CancellationToken);
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
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, post);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostImages_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
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
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.PostImages.ShouldSatisfy(request);
	}

	[Theory]
	[PostImagesEmptyData]
	[PostImagesJpegData]
	[PostImagesPngData]
	[PostImagesWebpData]
	[PostImagesJpegDifferentCaseData]
	[PostImagesPngDifferentCaseData]
	[PostImagesWebpDifferentCaseData]
	public async Task AddAsync_ShouldAddPostImages_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.PostImages.ShouldSatisfy(request);
	}
}
