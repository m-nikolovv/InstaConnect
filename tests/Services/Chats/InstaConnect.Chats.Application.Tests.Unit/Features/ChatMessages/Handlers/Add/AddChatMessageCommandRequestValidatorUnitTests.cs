using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Add;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Content;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Images;
using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Chats.Application.Tests.Unit.Features.ChatMessages.Handlers.Add;

public class AddChatMessageCommandRequestValidatorUnitTests : BaseChatMessageApplicationCommandUnitTest
{
	private readonly AddChatMessageCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddChatMessageCommandRequestBuilder _requestBuilder;
	private readonly AddChatMessageCommandRequest _request;

	private readonly AddChatMessageCommandRequestValidator _requestValidator;

	public AddChatMessageCommandRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Chat);
		_request = _requestBuilder.Build();

		_requestValidator = new();
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenParticipantOneIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForParticipantOneId(request, messageTransformer);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForParticipantTwoId(request, messageTransformer);
	}

	[Theory]
	[ChatMessageContentNullWithMessageData]
	[ChatMessageContentEmptyWithMessageData]
	[ChatMessageContentTooShortWithMessageData]
	[ChatMessageContentTooLongWithMessageData]
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
	[ChatMessageImagesTooManyWithMessageData]
	[ChatMessageImagesTooLargeWithMessageData]
	[ChatMessageImagesInvalidContentTypeWithMessageData]
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
	[ChatMessageImagesEmptyData]
	[ChatMessageImagesJpegData]
	[ChatMessageImagesPngData]
	[ChatMessageImagesWebpData]
	[ChatMessageImagesJpegDifferentCaseData]
	[ChatMessageImagesPngDifferentCaseData]
	[ChatMessageImagesWebpDifferentCaseData]
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
