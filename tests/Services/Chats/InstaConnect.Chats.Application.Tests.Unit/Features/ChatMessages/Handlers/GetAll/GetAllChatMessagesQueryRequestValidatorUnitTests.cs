using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Page;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.PageSize;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.SortOrder;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.SortTerm;
using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;

namespace InstaConnect.Chats.Application.Tests.Unit.Features.ChatMessages.Handlers.GetAll;

public class GetAllChatMessagesQueryRequestValidatorUnitTests : BaseChatMessageApplicationQueryUnitTest
{
	private readonly GetAllChatMessagesQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllChatMessagesQueryRequestBuilder _requestBuilder;
	private readonly GetAllChatMessagesQueryRequest _request;

	private readonly GetAllChatMessagesQueryRequestValidator _requestValidator;

	public GetAllChatMessagesQueryRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ChatMessage);
		_request = _requestBuilder.Build();

		_requestValidator = new();
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
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForCurrentUserId(request, messageTransformer);
	}

	[Theory]
	[ChatMessagesSortOrderEmptyWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForSortOrder(request, messageTransformer);
	}

	[Theory]
	[ChatMessagesSortTermEmptyWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenSortTermIsInvalid(
		IEnumTransformer<ChatMessagesSortTerm> transformer, IEnumMessageTransformer<ChatMessagesSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForSortTerm(request, messageTransformer);
	}

	[Theory]
	[ChatMessagePageTooSmallWithMessageData]
	[ChatMessagePageTooLargeWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenPageIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForPage(request, messageTransformer);
	}

	[Theory]
	[ChatMessagePageSizeTooSmallWithMessageData]
	[ChatMessagePageSizeTooLargeWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenPageSizeIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForPageSize(request, messageTransformer);
	}

	[Fact]
	public void TestValidate_ShouldNotHaveAnyValidationErrors_WhenRequestIsValid()
	{
		// Act
		var response = _requestValidator.TestValidate(_request);

		// Assert
		response.ShouldNotHaveAnyValidationErrorProperties();
	}
}
