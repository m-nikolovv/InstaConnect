using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Content;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Images;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Title;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Handlers.Add;

public class AddPostCommandRequestValidatorUnitTests : BasePostApplicationCommandUnitTest
{
	private readonly AddPostCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddPostCommandRequestBuilder _requestBuilder;
	private readonly AddPostCommandRequest _request;

	private readonly AddPostCommandRequestValidator _requestValidator;

	public AddPostCommandRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_requestValidator = new();
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForUserId(request, messageTransformer);
	}

	[Theory]
	[PostTitleNullWithMessageData]
	[PostTitleEmptyWithMessageData]
	[PostTitleTooShortWithMessageData]
	[PostTitleTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenTitleIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithTitle(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForTitle(request, messageTransformer);
	}

	[Theory]
	[PostContentNullWithMessageData]
	[PostContentEmptyWithMessageData]
	[PostContentTooShortWithMessageData]
	[PostContentTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenContentIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithContent(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForContent(request, messageTransformer);
	}

	[Theory]
	[PostImagesTooManyWithMessageData]
	[PostImagesTooLargeWithMessageData]
	[PostImagesInvalidContentTypeWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenImagesAreInvalid(
		IFormFileCollectionTransformer transformer, IFormFileCollectionMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForImages(request, messageTransformer);
	}

	[Fact]
	public void TestValidate_ShouldNotHaveAnyValidationErrors_WhenRequestIsValid()
	{
		// Act
		var response = _requestValidator.TestValidate(_request);

		// Assert
		response.ShouldNotHaveAnyValidationErrorProperties();
	}

	[Theory]
	[PostImagesEmptyData]
	[PostImagesJpegData]
	[PostImagesPngData]
	[PostImagesWebpData]
	[PostImagesJpegDifferentCaseData]
	[PostImagesPngDifferentCaseData]
	[PostImagesWebpDifferentCaseData]
	public void TestValidate_ShouldNotHaveAnyValidationErrors_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldNotHaveAnyValidationErrorProperties();
	}
}
